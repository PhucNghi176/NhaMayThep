using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQueryValidator: AbstractValidator<GetThongTinCongDoanByIdQuery>
    {
        public GetThongTinCongDoanByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã thông tin công đoàn không đúng định dạng");
        }
    }
}
