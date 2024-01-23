using FluentValidation;
using NhaMayThep.Application.LoaiTangCa.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetById
{
    public class GetLoaiTangCaValidator : AbstractValidator<GetLoaiTangCaByIdQuery>
    {
        public GetLoaiTangCaValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID is required");
        }
    }
}
