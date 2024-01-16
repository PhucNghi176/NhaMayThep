using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommandValidator: AbstractValidator<UpdateThongTinGiamTruGiaCanhCommand>
    {
        public UpdateThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Id must not be empty")
              .NotNull().WithMessage("Id must not be null")
              .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");

            RuleFor(x => x.MaGiamTruID)
                 .GreaterThan(0)
                 .WithMessage("MaGiamTruID must be greater than or equal to 0");

            RuleFor(x => x.QuanHeVoiNhanVien)
             .MaximumLength(20).WithMessage("Maximun length is 20");

            RuleFor(x => x.CanCuocCongDan)
             .NotEmpty().WithMessage("Id must not be empty")
             .NotNull().WithMessage("Id must not be null")
             .MaximumLength(12).WithMessage("Maximun length is 12")
             .Must(x => long.TryParse(x, out long _)).WithMessage("CanCuocCongDan must an digit");

            RuleFor(x => x.NgayXacNhanPhuThuoc)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayXacNhanPhuThuoc cannot be in the future");
        }
    }
}
