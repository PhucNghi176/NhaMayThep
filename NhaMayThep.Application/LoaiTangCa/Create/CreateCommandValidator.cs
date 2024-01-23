using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiNghiPhep.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        }


    }
}
