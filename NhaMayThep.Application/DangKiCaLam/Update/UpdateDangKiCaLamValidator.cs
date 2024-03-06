using FluentValidation;

namespace NhaMayThep.Application.DangKiCaLam.Update
{
    public class UpdateDangKiCaLamValidator : AbstractValidator<UpdateDangKiCaLamCommand>
    {
        public UpdateDangKiCaLamValidator()
        {
            RuleFor(x => x.MaCaLamViec)
                .GreaterThan(0).WithMessage("MaCaLamViec must be greater than 0.");

            RuleFor(x => x.NgayDangKi)
                 .NotEmpty().WithMessage("NgayDangKi is required.")
                 .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("NgayDangKi must be in the past or present.");

            RuleFor(x => x.CaDangKi)
                .GreaterThan(0).WithMessage("CaDangKi must be greater than 0.");

            RuleFor(x => x.ThoiGianCaLamBatDau)
                .NotEmpty().WithMessage("ThoiGianCaLamBatDau is required.");

            RuleFor(x => x.ThoiGianCaLamKetThuc)
                .NotEmpty().WithMessage("ThoiGianCaLamKetThuc is required.")
                .GreaterThan(x => x.ThoiGianCaLamBatDau).WithMessage("ThoiGianCaLamKetThuc must be after ThoiGianCaLamBatDau.");

            RuleFor(x => x.HeSoNgayCong)
                .GreaterThanOrEqualTo(0).WithMessage("HeSoNgayCong must be non-negative.");

            RuleFor(x => x.TrangThai)
                .GreaterThanOrEqualTo(0).WithMessage("TrangThai must be valid.");

            RuleFor(x => x.GhiChu)
                .MaximumLength(500).WithMessage("GhiChu must not exceed 500 characters.");

            // Optional fields like ThoiGianChamCongBatDau can have custom rules if necessary
            RuleFor(x => x.ThoiGianChamCongBatDau)
                .LessThanOrEqualTo(x => x.ThoiGianChamCongKetThuc).When(x => x.ThoiGianChamCongBatDau.HasValue && x.ThoiGianChamCongKetThuc.HasValue)
                .WithMessage("ThoiGianChamCongBatDau must be before or equal to ThoiGianChamCongKetThuc.");
        }
    }
}
