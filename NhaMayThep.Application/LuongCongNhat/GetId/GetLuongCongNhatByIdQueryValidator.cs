using FluentValidation;
using NhaMayThep.Application.LuongCongNhat.GetId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQueryValidator : AbstractValidator<GetLuongCongNhatByIdQuery>
    {
        public GetLuongCongNhatByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
