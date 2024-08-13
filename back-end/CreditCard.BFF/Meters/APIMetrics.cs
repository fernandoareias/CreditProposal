using System.Diagnostics.Metrics;

namespace CreditCard.Proposals.BFF.Meters;

public class APIMetrics
{
    private readonly Counter<int> _counterCache;
    private readonly Counter<int> _proposalStarted;

    public APIMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("api.metrics");
        _counterCache = meter.CreateCounter<int>("counter.cache");
        _proposalStarted= meter.CreateCounter<int>("counter.proposal_started");
    }


    public void IncrementCacheCounter(string type)
    {
        _counterCache.Add(1, new []
        {
            new KeyValuePair<string, object?>("type", type) 
        });
    }
    
    public void IncrementProposalStarted(string step, Guid proposalId)
    {
        _proposalStarted.Add(1, new []
        {
            new KeyValuePair<string, object?>("counter.proposal_step", step),
            new KeyValuePair<string, object?>("counter.proposal_id", proposalId),
        });
    }
    
    
}