using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Delete
{
    public class DeleteKyLuatCommandValidator : AbstractValidator<DeleteKyLuatCommand>
    {
        public DeleteKyLuatCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
