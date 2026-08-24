using System.Text;
using System.Text.Json;
using Models.DTO;
using RabbitMQ.Client;

namespace RabbitMQ;

public class RabbitMQProducer : IRabbitMQProducer
{
    private const string QueueName = "reminder_queue";

    public async Task PublishReminderAsync(
        ReminderMessageDTO reminder)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        await using var connection =
            await factory.CreateConnectionAsync();

        await using var channel =
            await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false);

        var message = JsonSerializer.Serialize(reminder);

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: QueueName,
            mandatory: false,
            basicProperties: new BasicProperties
            {
                Persistent = true
            },
            body: body);
    }
}