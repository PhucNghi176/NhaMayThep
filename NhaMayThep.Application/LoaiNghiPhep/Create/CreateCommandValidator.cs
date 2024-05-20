using FluentValidation;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateLoaiNghiPhepCommand>
    {
        private readonly ILoaiNghiPhepRepository _repository;

        public CreateCommandValidator(ILoaiNghiPhepRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Tên không để trống")
            .MaximumLength(100).WithMessage("Tên không vượt quá 100 chữ.");

        }


    }
}