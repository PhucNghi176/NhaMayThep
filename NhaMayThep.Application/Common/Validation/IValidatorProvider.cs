using FluentValidation;

namespace NhaMapThep.Application.Common.Validation
{
    public interface IValidatorProvider
    {
        IValidator<T> GetValidator<T>();
    }
}
