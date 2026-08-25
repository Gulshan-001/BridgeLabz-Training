namespace RabbitMQ.Interface;

public interface IEmailService
{
    Task SendReminderEmailAsync(
        string email,
        string noteTitle);
}