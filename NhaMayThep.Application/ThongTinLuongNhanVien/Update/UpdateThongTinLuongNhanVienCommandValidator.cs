using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandValidator : AbstractValidator<UpdateThongTinLuongNhanVienCommand>
    {
        public UpdateThongTinLuongNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã Số Nhân Viên Không Được Để Trống");

            RuleFor(x => x.MaSoHopDong)
                .NotEmpty().WithMessage("Mã Số Hợp Đồng Không Được Để Trống");

            RuleFor(x => x.Loai)
                .NotEmpty().WithMessage("Loại Không Được Để Trống")
                .Must(x => x == "TangLuong" || x == "GiamLuong")
                .WithMessage("Nhập liệu không hợp lệ, Nên là Tăng Lương hoặc Giám Lương"); ;

            RuleFor(x => x.LuongCu)
                .NotEmpty().WithMessage("Lương Cũ Không Được Để Trống")
                .GreaterThan(0).WithMessage("Lương Cũ phải lớn hơn 0");

            RuleFor(x => x.LuongMoi)
                .NotEmpty().WithMessage("Lương Hiện Tại Không Được Để Trống")
                .GreaterThan(0).WithMessage("Lương Hiện Tại phải lớn hơn 0")
                .When(x => x.Loai == "TangLuong")
                .GreaterThan(x => x.LuongCu).WithMessage("Lương Hiện Tại phải lớn hơn Lương Cũ");

            RuleFor(x => x.LuongCu)
                .GreaterThanOrEqualTo(x => x.LuongMoi)
                .When(x => x.Loai == "GiamLuong")
                .WithMessage("Lương Cũ phải lớn hơn hoặc bằng Lương Hiện Tại");

            RuleFor(x => x.NgayHieuLuc)
                .NotEmpty().WithMessage("Ngày Hiệu Lực Không Được Để Trống");

        }
    }
}
