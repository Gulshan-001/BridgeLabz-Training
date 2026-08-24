using Microsoft.Extensions.Hosting;
using RabbitMQ.Interface;

namespace Fundoo.Services;

public class RabbitMQConsumerService : BackgroundService
{
    private readonly IRabbitMQConsumer _rabbitMQConsumer;

    public RabbitMQConsumerService(
        IRabbitMQConsumer rabbitMQConsumer)
    {
        _rabbitMQConsumer = rabbitMQConsumer;
    }

    protected override Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        _rabbitMQConsumer.Start();

        return Task.CompletedTask;
    }
}