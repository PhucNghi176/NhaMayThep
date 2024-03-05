using FluentValidation;

namespace NhaMayThep.Application.DangKiTangCa.Update
{
    public class UpdateDangKiTangCaValidator : AbstractValidator<UpdateDangKiTangCaCommand>
    {
        public UpdateDangKiTangCaValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("ID is required for update.");

            RuleFor(v => v.MaSoNhanVien)
                .NotEmpty().WithMessage("Employee ID is required.");

            RuleFor(v => v.NgayLamTangCa)
                .NotEmpty().WithMessage("Overtime work date is required.");

            RuleFor(v => v.CaDangKi)
                .GreaterThan(0).WithMessage("Shift registration must be greater than 0.");

            RuleFor(v => v.LiDoTangCa)
                .NotEmpty().WithMessage("Reason for overtime is required.")
                .MaximumLength(500).WithMessage("Reason for overtime cannot be longer than 500 characters.");

            RuleFor(v => v.ThoiGianCaLamBatDau)
                .NotEmpty().WithMessage("Start time of the shift is required.");

            RuleFor(v => v.ThoiGianCaLamKetThuc)
                .NotEmpty().WithMessage("End time of the shift is required.")
                .GreaterThan(v => v.ThoiGianCaLamBatDau).WithMessage("End time must be after start time.");

            RuleFor(v => v.SoGioTangCa)
                .NotEmpty().WithMessage("Overtime hours are required.");

            RuleFor(v => v.HeSoLuongTangCa)
                .GreaterThan(0).WithMessage("Overtime pay rate must be greater than 0.");

            RuleFor(v => v.TrangThaiDuyet)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Approval status is invalid.");

            RuleFor(v => v.NguoiDuyet)
                .NotEmpty().WithMessage("Approver is required.");
        }
    }
}
