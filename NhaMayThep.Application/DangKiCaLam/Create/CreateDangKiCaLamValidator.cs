using FluentValidation;

namespace NhaMayThep.Application.DangKiCaLam.Create
{
    public class CreateDangKiCaLamValidator : AbstractValidator<CreateDangKiCaLamCommand>
    {
        public CreateDangKiCaLamValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã số nhân viên là bắt buộc.");

            RuleFor(x => x.NgayDangKi)
                .NotEmpty().WithMessage("Ngày đăng kí là bắt buộc.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Ngày đăng kí phải ở trong quá khứ hoặc hiện tại.");

            RuleFor(x => x.CaDangKi)
                .GreaterThan(0).WithMessage("Ca đăng kí phải lớn hơn 0.");

            RuleFor(x => x.ThoiGianCaLamBatDau)
                .NotEmpty().WithMessage("Thời gian ca làm bắt đầu là bắt buộc.");

            RuleFor(x => x.ThoiGianCaLamKetThuc)
                .NotEmpty().WithMessage("Thời gian ca làm kết thúc là bắt buộc.")
                .GreaterThan(x => x.ThoiGianCaLamBatDau).WithMessage("Thời gian ca làm kết thúc phải sau thời gian ca làm bắt đầu.");

            RuleFor(x => x.HeSoNgayCong)
                .GreaterThanOrEqualTo(0).WithMessage("Hệ số ngày công phải không âm.");

            RuleFor(x => x.TrangThai)
                .GreaterThanOrEqualTo(0).WithMessage("Trạng thái phải hợp lệ.");

            RuleFor(x => x.GhiChu)
                .MaximumLength(500).WithMessage("Ghi chú không được vượt quá 500 ký tự.");

            RuleFor(x => x.ThoiGianChamCongBatDau)
                .LessThanOrEqualTo(x => x.ThoiGianChamCongKetThuc).When(x => x.ThoiGianChamCongBatDau.HasValue && x.ThoiGianChamCongKetThuc.HasValue)
                .WithMessage("Thời gian chấm công bắt đầu phải trước hoặc bằng Thời gian chấm công kết thúc.");
        }
    }
}
