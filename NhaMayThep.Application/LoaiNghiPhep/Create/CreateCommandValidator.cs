using FluentValidation;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            RuleFor(command => command.Id)
               .MustAsync(async (id, cancellation) => !await IdExists(id))
               .WithMessage("The ID already exists.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(command => command.SoGioNghiPhep)
           .GreaterThanOrEqualTo(0).WithMessage("Number of leave hours must be non-negative.")
           .LessThanOrEqualTo(24).WithMessage("Number of leave hours must not exceed 24.");
        }

        private async Task<bool> IdExists(int id)
        {
            var existingEntity = await _repository.FindByIdAsync(id);
            return existingEntity != null;
        }
    }
}