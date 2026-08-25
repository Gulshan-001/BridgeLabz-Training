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
    private readonly IEmailService _emailService;

    public RabbitMQConsumer(IEmailService emailService)
    {
        _emailService = emailService;

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
            try
            {
                var body = eventArgs.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                var reminder =
                    JsonSerializer.Deserialize<ReminderMessageDTO>(
                        message
                    );

                if (reminder != null)
                {
                    await _emailService.SendReminderEmailAsync(
                        reminder.Email,
                        reminder.NoteTitle
                    );

                    Console.WriteLine(
                        $"Reminder email sent to: {reminder.Email}"
                    );
                }

                await _channel.BasicAckAsync(
                    eventArgs.DeliveryTag,
                    false
                );
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    $"Failed to process reminder: {exception.Message}"
                );
            }
        };

        _channel.BasicConsumeAsync(
                queue: "reminder_queue",
                autoAck: false,
                consumer: consumer)
            .GetAwaiter()
            .GetResult();
    }
}