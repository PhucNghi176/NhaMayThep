using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommandValidator : AbstractValidator<CreateThongTinGiamTruGiaCanhCommand>
    {
        public CreateThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
               .NotEmpty().WithMessage("NhanVienID must not be empty")
               .NotNull().WithMessage("NhanVienID must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The NhanVienID is not correct");

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
             .Must(x => long.TryParse(x, out long _)).WithMessage("CanCuocCongDan must an digit");

            RuleFor(x => x.NgayXacNhanPhuThuoc)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayXacNhanPhuThuoc cannot be in the future");

        }
    }
}
