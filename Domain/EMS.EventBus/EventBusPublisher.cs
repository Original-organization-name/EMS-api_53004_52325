using System.Text;
using System.Text.Json;
using EMS.EventBus.Abstractions;
using EMS.EventBus.Helpers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EMS.EventBus;

public class EventBusPublisher
{
    public async Task<TResponse?> PublishAsync<TResponse>(IEventBusRequest request)
    {
        var queueName = request.GetType().GetQueueName();
        var responseQueueName = Guid.NewGuid().ToString();

        var factory = new ConnectionFactory { 
            HostName = "rabbitmq" ,   
            UserName = "admin",
            Password = "admin"
        };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();
        
        await channel.QueueDeclareAsync(
            queue: queueName, 
            durable: false, 
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var json = JsonSerializer.Serialize(request);
        var body = Encoding.UTF8.GetBytes(json);
        
        var props = new BasicProperties
        {
            ReplyTo = responseQueueName
        };

        var tcs = new TaskCompletionSource<TResponse?>();
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            var response = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            var result = JsonSerializer.Deserialize<TResponse>(response);
            tcs.SetResult(result);
        };
        
        await channel.BasicConsumeAsync(
            consumer: consumer,
            queue: responseQueueName,
            autoAck: true);
        
        await channel.BasicPublishAsync(
            exchange: string.Empty, 
            routingKey: queueName,
            mandatory: false,
            basicProperties: props,
            body: body);
        
        return await tcs.Task;
    }
}
