using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVienIDByEmail
{
    public class GetNhanVienIDByEmailQueryValidator : AbstractValidator<GetNhanVienIDByEmailQuery>
    {
        public GetNhanVienIDByEmailQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email không để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");
        }
    }
}
