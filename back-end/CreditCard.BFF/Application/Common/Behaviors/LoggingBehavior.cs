using System.Diagnostics;
using System.Text.Json;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CreditCard.Proposals.BFF.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : View
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                // Log request body
                var requestBody = JsonSerializer.Serialize(request);
                _logger.LogInformation($"Handling {typeof(TRequest).Name} with request body: {requestBody}");

                // Process the request
                var response = await next();

                // Log response body
                var responseBody = JsonSerializer.Serialize(response);
                _logger.LogInformation($"Handled {typeof(TResponse).Name} with response body: {responseBody}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error handling {typeof(TRequest).Name}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation($"Processing {typeof(TRequest).Name} took {stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}