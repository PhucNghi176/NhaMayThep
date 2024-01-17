using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetById
{
    public class GetKyLuatByIdQueryValidator : AbstractValidator<GetKyLuatByIdQuery>
    {
        public GetKyLuatByIdQueryValidator()
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
