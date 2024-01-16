using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLSNPValidator : AbstractValidator<DeleteLSNPCommand>
    {
        public DeleteLSNPValidator() {
            ConfigureValidationRules();
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is requied");
        }
    }
}
