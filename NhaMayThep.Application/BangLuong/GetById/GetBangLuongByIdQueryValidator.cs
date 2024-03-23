using FluentValidation;
using NhaMayThep.Application.BangLuong.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.GetById
{
    public class GetBangLuongByIdQueryValidator : AbstractValidator<GetBangLuongByIdQuery>
    {
        public GetBangLuongByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
