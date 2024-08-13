using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.CrossCutting.Validators;
using CreditCard.Proposals.BFF.DTOs.Responses.Common;
using FluentValidation;
using MediatR;

namespace CreditCard.Proposals.BFF.Application.Common.Behaviors;

public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> where TResponse : View
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    private readonly IValidatorServices _validatorServices;
    public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators, IValidatorServices validatorServices)
    {
        _validators = validators;
        _validatorServices = validatorServices;
    }


    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (!failures.Any())
            return next();

        failures.ForEach(c => _validatorServices.AddError(EErroType.BUSINESS.ToString(), c.ErrorMessage));

        return Task.FromResult<TResponse>(null);
    }

}