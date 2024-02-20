using FluentValidation;
using NhaMayThep.Application.PhuCapCongDoan.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.Delete
{
    public class DeletePhuCapCongDoanCommandValidator : AbstractValidator<DeletePhuCapCongDoanCommand>
    {
        public DeletePhuCapCongDoanCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID không được để trống");
        }
    }
}
