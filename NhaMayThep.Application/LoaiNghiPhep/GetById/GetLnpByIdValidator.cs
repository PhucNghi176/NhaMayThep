using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLnpByIdValidator : AbstractValidator<GetLnpByIdQuery>
    {

        public GetLnpByIdValidator() {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID is required");
        }
    }
}
