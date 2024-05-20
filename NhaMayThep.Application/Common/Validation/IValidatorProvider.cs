using FluentValidation;

namespace NhaMayThep.Application.Common.Validation
{
    public interface IValidatorProvider
    {
        IValidator<T> GetValidator<T>();
    }
}
