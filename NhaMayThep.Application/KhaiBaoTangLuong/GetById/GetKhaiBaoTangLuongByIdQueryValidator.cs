using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetById
{
    public class GetKhaiBaoTangLuongByIdQueryValidator : AbstractValidator<GetKhaiBaoTangLuongByIdQuery>
    {
        public GetKhaiBaoTangLuongByIdQueryValidator()
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
