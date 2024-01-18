using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandValidator : AbstractValidator<UpdateThongTinCongDoanCommand>
    {
        public UpdateThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty")
                .NotNull().WithMessage("Id must not be null")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("NhanVienId must not be empty")
                .NotNull().WithMessage("NhanVienId must not be null")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The NhanVienID is not correct");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("ThuKyCongDoan must be either true or false");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayGiaNhap cannot be in the future");

        }
    }
}
