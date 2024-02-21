using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommandValidator: AbstractValidator<RestoreThongTinCongDoanCommand>
    {
        public RestoreThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
                .NotNull().WithMessage("Mã thông tin công đoàn không được rỗng");
        }
    }
}
