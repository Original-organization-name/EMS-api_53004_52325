using System.Reflection;
using System.Text;
using System.Text.Json;
using EMS.EventBus.Abstractions;
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
        Console.WriteLine("[RabbitMQListenerService] Starting...");

        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq",
            UserName = "admin",
            Password = "admin"
        };

        _connection = await factory.CreateConnectionAsync(cancellationToken);
        _channel = await _connection.CreateChannelAsync(cancellationToken: cancellationToken);
        
        await RegisterRequestHandlerAsync();
    }

    private async Task RegisterRequestHandlerAsync()
    {
        var requestIType = typeof(IEventBusRequestHandler<,>);
        var handlerTypes = Assembly.GetEntryAssembly()?
            .GetTypes()
            .Where(type => type
                .GetInterfaces()
                .Any(i => i.IsGenericType 
                          && i.GetGenericTypeDefinition() == requestIType))
            .ToList();

        foreach (var handlerType in handlerTypes ?? new List<Type>())
        {
            var eventType = handlerType
                .GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == requestIType)
                .GetGenericArguments()[0];

            var queueName = eventType.GetQueueName();
            await StartListeningAsync(eventType, handlerType, queueName);
        }
    }

    private async Task StartListeningAsync(Type eventType, Type handlerType, string queueName)
    {
        if (_channel is null)
        {
            throw new ArgumentNullException(nameof(_channel));
        }
        
        await _channel.QueueDeclareAsync(
            queue: queueName, 
            durable: false, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            
            try
            {
                var @event = JsonSerializer.Deserialize(message, eventType);
                if (@event != null)
                {
                    using var scope = serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetService(handlerType);

                    if (handler != null)
                    {
                        var handleMethod = handlerType.GetMethod("HandleAsync");
                        dynamic awaitable = handleMethod!.Invoke(handler, new[] { @event })!;
                        var result = await awaitable;

                        var json = JsonSerializer.Serialize(result);
                        
                        var props = eventArgs.BasicProperties;
                        var replyProps = new BasicProperties
                        {
                        };
                    
                        await _channel.BasicPublishAsync(
                            exchange: string.Empty,
                            routingKey: props.ReplyTo,
                            mandatory: false,
                            basicProperties: replyProps,
                            body: Encoding.UTF8.GetBytes(json));
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] No handler registered for event type {eventType.Name}");
                    }
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
    
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("[RabbitMQListenerService] Stopping...");
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