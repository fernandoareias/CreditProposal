using FluentValidation.Results;

namespace CreditCard.Proposals.BFF.CrossCutting.Validators;

public interface IValidatorServices
{
    ValidationResult ValidationResult { get; set; }
    void AddError(string message);

    void AddError(string code, string message);
    void AddError(ValidationResult validationResult);
}