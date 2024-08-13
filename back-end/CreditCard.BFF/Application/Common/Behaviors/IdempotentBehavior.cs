using System.Text.Json;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.Meters;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CreditCard.Proposals.BFF.Application.Common.Behaviors;
public class IdempotentBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : View
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<IdempotentBehavior<TRequest, TResponse>> _logger;
    private readonly APIMetrics _metrics;
    public IdempotentBehavior(
        IDistributedCache cache, 
        ILogger<IdempotentBehavior<TRequest, TResponse>> logger,
        APIMetrics metrics)
    {
        _cache = cache;
        _logger = logger;
        _metrics = metrics;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var command = request as Command<TResponse>;
        string cacheKey = $"{typeof(TRequest).Name}:{command.IdempotencyKey}";

        var cacheResponse = await ReadCache(cacheKey, command.IdempotencyKey, cancellationToken);

        if (cacheResponse != null) return cacheResponse;
        
        var response = await next();

        if (response != null)
            await WriteCache(response, cacheKey, command.IdempotencyKey, cancellationToken);
            
        return response;
    }

    private async Task<TResponse?> ReadCache(string cacheKey, Guid idempotencyKey, CancellationToken cancellationToken)
    {
        try
        {
            string cachedResponse = await _cache.GetStringAsync(cacheKey, cancellationToken);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                _metrics.IncrementCacheCounter("hit");
                _logger.LogInformation($"Returning cached response for {typeof(TRequest).Name} with idempotency key {idempotencyKey}");
                return JsonSerializer.Deserialize<TResponse>(cachedResponse);
            }
            _metrics.IncrementCacheCounter("miss");

        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }
        return null;
    }
    private async Task WriteCache(TResponse response, string cacheKey, Guid idempotencyKey, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                $"Caching response for {typeof(TRequest).Name} with idempotency key {idempotencyKey}");
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(response), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            }, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }
    }
    
}


