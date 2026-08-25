using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using RabbitMQ.Interface;

namespace RabbitMQ.Service;

public class EmailService : IEmailService
{
    private readonly string _email;
    private readonly string _password;

    public EmailService()
    {
        _email = Environment.GetEnvironmentVariable(
            "EMAIL_ADDRESS"
        ) ?? throw new InvalidOperationException(
            "EMAIL_ADDRESS is missing."
        );

        _password = Environment.GetEnvironmentVariable(
            "EMAIL_PASSWORD"
        ) ?? throw new InvalidOperationException(
            "EMAIL_PASSWORD is missing."
        );
    }

    public async Task SendReminderEmailAsync(
        string email,
        string noteTitle)
    {
        var message = new MimeMessage();

        message.From.Add(
            MailboxAddress.Parse(_email)
        );

        message.To.Add(
            MailboxAddress.Parse(email)
        );

        message.Subject = $"Reminder: {noteTitle}";

        message.Body = new TextPart("plain")
        {
            Text =
                $"Hey!\n\n" +
                $"This is a reminder for your note:\n\n" +
                $"{noteTitle}\n\n" +
                $"— Fundoo App"
        };

        using var client = new SmtpClient();

        await client.ConnectAsync(
            "smtp.gmail.com",
            587,
            SecureSocketOptions.StartTls
        );

        await client.AuthenticateAsync(
            _email,
            _password
        );

        await client.SendAsync(message);

        await client.DisconnectAsync(true);
    }
}