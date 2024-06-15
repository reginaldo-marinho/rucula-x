using FluentValidation;
using FluentValidation.Results;

namespace RuculaX.Core;

public sealed class ValidationEntity<T> : IValidationEntity<T> where T : class
{
    private readonly AbstractValidator<T> _validator;
    public ValidationResult result { get; set; }
    public ValidationEntity(AbstractValidator<T> validator, T target)
    {
        _validator = validator;
        Validate(target);
    }
    public ValidationResult Validate(T target)
    {
        result =_validator.Validate(target);
        return result;
    }
}
