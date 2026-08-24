using System.Text;
using System.Text.Json;
using Models.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Interface;

namespace RabbitMQ.Service;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IConnection _connection;
    private readonly IChannel _channel;

    public RabbitMQConsumer()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = factory.CreateConnectionAsync()
            .GetAwaiter()
            .GetResult();

        _channel = _connection.CreateChannelAsync()
            .GetAwaiter()
            .GetResult();

        _channel.QueueDeclareAsync(
                queue: "reminder_queue",
                durable: true,
                exclusive: false,
                autoDelete: false)
            .GetAwaiter()
            .GetResult();
    }

    public void Start()
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.ReceivedAsync += async (sender, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();

            var message = Encoding.UTF8.GetString(body);

            var reminder = JsonSerializer.Deserialize<ReminderMessageDTO>(
                message
            );

            if (reminder != null)
            {
                Console.WriteLine(
                    $"Reminder received for: {reminder.Email}"
                );

                Console.WriteLine(
                    $"Note: {reminder.NoteTitle}"
                );
            }

            await _channel.BasicAckAsync(
                eventArgs.DeliveryTag,
                false
            );
        };

        _channel.BasicConsumeAsync(
                queue: "reminder_queue",
                autoAck: false,
                consumer: consumer)
            .GetAwaiter()
            .GetResult();
    }
}