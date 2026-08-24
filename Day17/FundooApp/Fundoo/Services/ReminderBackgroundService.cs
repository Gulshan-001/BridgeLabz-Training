using Models.DTO;
using RabbitMQ;
using Repository.Interface;

namespace Fundoo.Services;

public class ReminderBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IRabbitMQProducer _rabbitMQProducer;

    public ReminderBackgroundService(
        IServiceScopeFactory scopeFactory,
        IRabbitMQProducer rabbitMQProducer)
    {
        _scopeFactory = scopeFactory;
        _rabbitMQProducer = rabbitMQProducer;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var noteRepository = scope.ServiceProvider
                .GetRequiredService<INoteRepository>();

            var dueReminders = await noteRepository
                .GetDueRemindersAsync();

            foreach (var note in dueReminders)
            {
                var reminderMessage = new ReminderMessageDTO
                {
                    NoteId = note.Id,
                    UserId = note.UserId,
                    Email = note.User.Email,
                    NoteTitle = note.Title,
                    ReminderTime = note.ReminderTime!.Value
                };

                await _rabbitMQProducer
                    .PublishReminderAsync(reminderMessage);
            }

            await Task.Delay(
                TimeSpan.FromSeconds(30),
                stoppingToken);
        }
    }
}