using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLoaiNghiPhepValidator : AbstractValidator<GetLoaiNghiPhepByIdQuery>
    {
        public GetLoaiNghiPhepValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID không để trống");
        }
    }
}
