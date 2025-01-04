using System.Text;
using System.Text.Json;
using EMS.EventBus.Abstractions;
using EMS.EventBus.Config;
using EMS.EventBus.Helpers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EMS.EventBus;

public class EventBusPublisher
{
    public async Task<TResponse?> PublishAsync<TResponse>(IEventBusRequest request)
    {
        var queueName = request.GetType().GetQueueName();
        var correlationId = Guid.NewGuid().ToString();
        var responseQueueName = $"amq.rabbitmq.reply-to";

        var factory = EventBusConfig.ConnectionFactory;
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var json = JsonSerializer.Serialize((object)request);
        var body = Encoding.UTF8.GetBytes(json);

        var tcs = await SubscribeToReply<TResponse>(channel, responseQueueName, correlationId);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: queueName,
            mandatory: false,
            basicProperties: new BasicProperties
            {
                ReplyTo = responseQueueName,
                CorrelationId = correlationId
            },
            body: body);

        return await tcs.Task;
    }

    private static async Task<TaskCompletionSource<TResponse?>> SubscribeToReply<TResponse>(IChannel channel,
        string responseQueueName, string correlationId)
    {
        var tcs = new TaskCompletionSource<TResponse?>();
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            if (eventArgs.BasicProperties.CorrelationId == correlationId)
            {
                var response = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var result = JsonSerializer.Deserialize<TResponse>(response);
                tcs.SetResult(result);
            }
        };

        await channel.BasicConsumeAsync(
            consumer: consumer,
            queue: responseQueueName,
            autoAck: true);

        return tcs;
    }
}