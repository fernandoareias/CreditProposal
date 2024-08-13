using System.Text.Json;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.ExternalServices.DTOs;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace CreditCard.Proposals.BFF.Infrastructure.Repositories;

public class SketchProposalRepository : ISketchProposalRepository
{
    private readonly IDistributedCache _cache;
    private readonly ConnectionMultiplexer _redis;
    public SketchProposalRepository(IDistributedCache cache, IConfiguration configuration)
    {
        _cache = cache;
        _redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
    }

    public async Task<SketchProposal> Get(string document)
    {
        try
        {
            string cachedResponse = await _cache.GetStringAsync($"SketchProposal:{document}");
            SketchProposal? proposal = null;

            if (string.IsNullOrWhiteSpace(cachedResponse)) return null;

            return JsonSerializer.Deserialize<SketchProposal>(cachedResponse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task Save(string document, SketchProposal proposal)
    {
        await _cache.SetStringAsync($"SketchProposal:{document}", JsonSerializer.Serialize(proposal), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(3)
        });

        await PublishEvents(proposal.Events);
    }


    private async Task PublishEvents(IReadOnlyCollection<Event> events)
    {
        var db = _redis.GetDatabase();
        
        foreach (var e in events)
        {
            string json = JsonSerializer.Serialize(e);
            string topic = e.GetType().Name;
            await db.StreamAddAsync(topic, new NameValueEntry[] { new NameValueEntry("json", json) });
        }
    }
}