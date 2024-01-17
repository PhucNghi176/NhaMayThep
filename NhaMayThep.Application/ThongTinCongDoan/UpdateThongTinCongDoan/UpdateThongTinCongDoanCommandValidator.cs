using FluentValidation;
using NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandValidator: AbstractValidator<UpdateThongTinCongDoanCommand>
    {
        public UpdateThongTinCongDoanCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
                .NotNull().WithMessage("Mã thông tin công đoàn không được rỗng")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã thông tin công đoàn không đúng định dạng");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống")
                .NotNull().WithMessage("Mã nhân viên không được để rỗng")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên không đúng định dạng");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("Thư ký cộng đoàn không đúng định dạng");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("Ngày gia nhập không thể lớn hơn ngày hiện tại"); ;

        }
    }
}
