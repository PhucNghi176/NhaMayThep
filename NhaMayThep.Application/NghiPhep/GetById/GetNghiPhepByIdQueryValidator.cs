using FluentValidation;
using NhaMayThep.Application.NghiPhep.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetNghiPhepByIdQueryValidator : AbstractValidator<GetNghiPhepByIdQuery>
    {
        public GetNghiPhepByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
