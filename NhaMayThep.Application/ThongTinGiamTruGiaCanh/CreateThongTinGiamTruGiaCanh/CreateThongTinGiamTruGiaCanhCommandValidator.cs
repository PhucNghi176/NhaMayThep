using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommandValidator: AbstractValidator<CreateThongTinGiamTruGiaCanhCommand>
    {
        public CreateThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
               .NotEmpty().WithMessage("Mã nhân viên không được bỏ trống")
               .NotNull().WithMessage("Mã nhân viên không được rỗng")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên sai định dạng");

            RuleFor(x => x.MaGiamTruID)
                 .GreaterThan(0)
                 .WithMessage("Mã giảm trừ phải lớn hơn 0")
                 .LessThan(int.MaxValue).WithMessage($"Mã giảm trừ phải bé hơn {int.MaxValue}");


            RuleFor(x => x.DiaChiLienLac)
              .NotEmpty().WithMessage("Mã nhân viên không được rỗng")
              .NotNull().WithMessage("Mã nhân viên không được bỏ trống");

            RuleFor(x => x.QuanHeVoiNhanVien)
             .NotEmpty().WithMessage("QuanHeVoiNhanVien must not be empty")
             .NotNull().WithMessage("QuanHeVoiNhanVien must not be null")
             .MaximumLength(20).WithMessage("Maximun length is 20");

            RuleFor(x => x.CanCuocCongDan)
             .NotEmpty().WithMessage("CanCuocCongDan must not be empty")
             .NotNull().WithMessage("CanCuocCongDan must not be null")
             .MaximumLength(12).WithMessage("Maximun length is 12")
             .Must(x=> long.TryParse(x, out long _)).WithMessage("CanCuocCongDan must an digit");

            RuleFor(x => x.NgayXacNhanPhuThuoc)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayXacNhanPhuThuoc cannot be in the future");

        }
    }
}
