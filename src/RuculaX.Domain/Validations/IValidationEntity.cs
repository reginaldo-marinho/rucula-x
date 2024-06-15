

using FluentValidation.Results;

namespace RuculaX.Core;

public interface IValidationEntity<T> where T: class
{
    ValidationResult Validate(T target);
}
