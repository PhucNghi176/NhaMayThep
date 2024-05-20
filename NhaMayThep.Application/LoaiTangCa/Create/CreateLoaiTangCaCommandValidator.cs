using FluentValidation;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiTangCa.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateLoaiTangCaCommand>
    {
        private readonly ILoaiTangCaRepository _repository;

        public CreateCommandValidator(ILoaiTangCaRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(command => command.Name)
            .NotNull().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        }


    }
}