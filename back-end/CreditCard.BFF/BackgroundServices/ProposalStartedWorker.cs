using System.Text.Json;
using CreditCard.Proposals.BFF.ExternalServices.DTOs.Events;
using StackExchange.Redis;

namespace CreditCard.Proposals.BFF.BackgroundServices;

public class ProposalStartedWorker : BackgroundService
{

    private readonly ConnectionMultiplexer _redis;
    private readonly ILogger<ProposalStartedWorker> _logger;
    public ProposalStartedWorker(IConfiguration configuration, ILogger<ProposalStartedWorker> logger)
    {
        _redis =  ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
        _logger = logger;
    }
    
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var db = _redis.GetDatabase();
        const string streamName = "ProposalStarted";
        const string groupName = "proposals-bff";
        const string consumerName = "avg-1";

        // Cria o grupo de consumidores se não existir
        try
        {
            await db.StreamCreateConsumerGroupAsync(streamName, groupName, StreamPosition.NewMessages, false);
            _logger.LogInformation("[CONSUMER] - Consumer group created or already exists.");
        }
        catch (RedisServerException ex) when (ex.Message.StartsWith("BUSYGROUP"))
        {
            _logger.LogInformation("[CONSUMER] - Consumer group already exists.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[CONSUMER] - Error creating consumer group.");
        }

        string id = string.Empty;
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("[CONSUMER] - Trying to consume a message...");

                var result = await db.StreamReadGroupAsync(streamName, groupName, consumerName, ">", 1);
                if (result.Any())
                {
                    var entry = result.First();
                    id = entry.Id;
                    _logger.LogInformation("[CONSUMER] - Consumed message with ID: {Id}", id);

                    // Desserializa o JSON
                    var json = entry.Values.FirstOrDefault(v => v.Name == "json").Value;
                    var proposalStarted = JsonSerializer.Deserialize<ProposalStarted>(json);

                    // Processamento da mensagem desserializada
                    if (proposalStarted != null)
                    {
                        _logger.LogInformation("[CONSUMER] - Processing message for proposal: {ProposalId}", proposalStarted.ProposalId);
                        // Coloque aqui a lógica de processamento necessária
                    }

                    // Acknowledge the message
                    await db.StreamAcknowledgeAsync(streamName, groupName, id);
                    _logger.LogInformation("[CONSUMER] - Acknowledged message with ID: {Id}", id);
                    id = string.Empty; // Reset ID after acknowledgement
                }
                else
                {
                    _logger.LogInformation("[CONSUMER] - No messages to consume.");
                }

                // Delay to prevent tight loop
                await Task.Delay(1000, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[CONSUMER] - An error occurred while consuming messages.");
            }
        }
    }

}