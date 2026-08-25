using Models.DTO;

namespace RabbitMQ;

public interface IRabbitMQProducer
{
    Task PublishReminderAsync(ReminderMessageDTO reminder);
}