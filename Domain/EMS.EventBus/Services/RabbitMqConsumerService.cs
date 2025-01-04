using System.Reflection;
using System.Text;
using System.Text.Json;
using EMS.EventBus.Abstractions;
using EMS.EventBus.Config;
using EMS.EventBus.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EMS.EventBus.Services;

public class RabbitMqConsumerService(IServiceProvider serviceProvider)
    : IHostedService
{
    private IConnection? _connection;
    private IChannel? _channel;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[EventBus] Starting...");

        var factory = EventBusConfig.ConnectionFactory;
        _connection = await factory.CreateConnectionAsync(cancellationToken);
        _channel = await _connection.CreateChannelAsync(cancellationToken: cancellationToken);
        
        await _channel.BasicQosAsync(
            prefetchSize: 0,
            prefetchCount: 20, 
            global: false, 
            cancellationToken: cancellationToken);

        await RegisterRequestHandlerAsync();
    }

    private async Task RegisterRequestHandlerAsync()
    {
        var handlerTypes = ScanAssemblyForHandlers();
        foreach (var handlerType in handlerTypes)
        {
            var eventType = GetEventType(handlerType);
            await StartListeningAsync(eventType, handlerType);
        }
    }

    private static IEnumerable<Type> ScanAssemblyForHandlers()
    {
        var handlerTypes = Assembly.GetEntryAssembly()?
            .GetTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventBusRequestHandler<,>)))
            .ToList();
        return handlerTypes ?? new List<Type>();
    }

    private static Type GetEventType(Type handlerType)
    {
        return handlerType
            .GetInterfaces()
            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventBusRequestHandler<,>))
            .GetGenericArguments()[0];
    }

    private async Task StartListeningAsync(Type eventType, Type handlerType)
    {
        if (_channel is null)
        {
            throw new ArgumentNullException(nameof(_channel));
        }

        var queueName = eventType.GetQueueName();

        await _channel.QueueDeclareAsync(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            try
            {
                var @event = DeserializeEvent(eventType, eventArgs);
                if (@event != null)
                {
                    _ = Task.Run(async () => { await HandleEvent(eventType, handlerType, @event, eventArgs); });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Failed to process message: {ex.Message}");
                await _channel.BasicNackAsync(eventArgs.DeliveryTag, false, false);
            }
        };

        await _channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);
        Console.WriteLine($"[*] Listening on queue: {queueName} for event type: {eventType.Name}");
    }

    private static object? DeserializeEvent(Type eventType, BasicDeliverEventArgs eventArgs)
    {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        return JsonSerializer.Deserialize(message, eventType);
    }
    
    private async Task HandleEvent(Type eventType, Type handlerType, object @event, BasicDeliverEventArgs eventArgs)
    {
        if (_channel is null)
        {
            throw new ArgumentNullException(nameof(_channel));
        }

        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetService(handlerType);

        if (handler != null)
        {
            var result = await CallHandler(handlerType, handler, @event);
            var json = JsonSerializer.Serialize(result);

            await _channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: eventArgs.BasicProperties.ReplyTo ??
                            throw new ArgumentNullException(nameof(eventArgs.BasicProperties.ReplyTo)),
                mandatory: false,
                basicProperties: new BasicProperties()
                {
                    CorrelationId = eventArgs.BasicProperties.CorrelationId
                },
                body: Encoding.UTF8.GetBytes(json));
        }
        else
        {
            Console.WriteLine($"[Warning] No handler registered for event type {eventType.Name}");
        }
    }
    
    private static async Task<object> CallHandler(Type handlerType, object handler, object @event)
    {
        var handleMethod = handlerType.GetMethod("HandleAsync");
        dynamic awaitable = handleMethod!.Invoke(handler, new[] { @event })!;
        return await awaitable;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[EventBus] Stopping...");
        if (_channel is not null)
        {
            await _channel.CloseAsync(cancellationToken);
        }

        if (_connection is not null)
        {
            await _connection.CloseAsync(cancellationToken);
        }
    }
}