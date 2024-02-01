using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.GetId
{
    public class GetLoaiTangCaByIdQueryValidator : AbstractValidator<GetLoaiTangCaByIdQuery>
    {
        public GetLoaiTangCaByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID is required");
        }
    }
}
