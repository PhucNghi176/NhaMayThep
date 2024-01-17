using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQueryValidator: AbstractValidator<GetThongTinCongDoanByNhanVienIdQuery>
    {
        public GetThongTinCongDoanByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Mã nhân viên không được để trống")
               .NotNull().WithMessage("Mã nhân viên không được rỗng")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên không đúng định dạng");
        }
    }
}
