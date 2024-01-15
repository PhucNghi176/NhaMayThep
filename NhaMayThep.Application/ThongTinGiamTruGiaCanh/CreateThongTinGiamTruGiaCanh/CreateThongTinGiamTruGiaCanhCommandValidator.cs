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
               .NotEmpty().WithMessage("NhanVienID must not be empty")
               .NotNull().WithMessage("NhanVienID must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Invalid NhanVienID Format");

            RuleFor(x => x.MaGiamTruID)
                 .GreaterThan(0)
                 .WithMessage("MaGiamTruID must be greater than or equal to 0");

            RuleFor(x => x.DiaChiLienLac)
              .NotEmpty().WithMessage("NhanVienID must not be empty")
              .NotNull().WithMessage("NhanVienID must not be null");

            RuleFor(x => x.QuanHeVoiNhanVien)
             .NotEmpty().WithMessage("QuanHeVoiNhanVien must not be empty")
             .NotNull().WithMessage("QuanHeVoiNhanVien must not be null")
             .MaximumLength(20).WithMessage("Maximun length is 20");

            RuleFor(x => x.CanCuocCongDan)
             .NotEmpty().WithMessage("CanCuocCongDan must not be empty")
             .NotNull().WithMessage("CanCuocCongDan must not be null")
             .MaximumLength(12).WithMessage("Maximun length is 12")
             .Must(x=> long.TryParse(x, out long _)).WithMessage("CanCuocCongDan must an integer");

            RuleFor(x => x.NgayXacNhanPhuThuoc)
               .NotEmpty().WithMessage("NgayXacNhanPhuThuoc must not emptty")
               .NotNull().WithMessage("NgayXacNhanPhuThuoc must not null")
               .Must(x => x is DateTime).WithMessage("NgayXacNhanPhuThuoc must be DateTime");

        }
    }
}
