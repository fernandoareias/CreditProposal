using FluentValidation.Results;

namespace CreditCard.Proposals.BFF.CrossCutting.Validators;

public class ValidatorServices : IValidatorServices
{
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();

    public void AddError(string message)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
    }

    public void AddError(string code, string message)
    {
        ValidationResult.Errors.Add(new ValidationFailure(code, message));
    }

    public void AddError(ValidationResult validationResult)
    {
        ValidationResult.Errors.AddRange(validationResult.Errors);
    }
}