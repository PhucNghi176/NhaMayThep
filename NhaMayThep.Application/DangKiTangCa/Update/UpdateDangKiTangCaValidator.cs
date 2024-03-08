using FluentValidation;

namespace NhaMayThep.Application.DangKiTangCa.Update
{
    public class UpdateDangKiTangCaValidator : AbstractValidator<UpdateDangKiTangCaCommand>
    {
        public UpdateDangKiTangCaValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("ID là bắt buộc để cập nhật.");

            RuleFor(v => v.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã số nhân viên là bắt buộc.");

            RuleFor(v => v.NgayLamTangCa)
                .NotEmpty().WithMessage("Ngày làm tăng ca là bắt buộc.");

            RuleFor(v => v.CaDangKi)
                .GreaterThan(0).WithMessage("Ca đăng kí phải lớn hơn 0.");

            RuleFor(v => v.LiDoTangCa)
                .NotEmpty().WithMessage("Lý do làm tăng ca là bắt buộc.")
                .MaximumLength(500).WithMessage("Lý do làm tăng ca không được dài hơn 500 ký tự.");

            RuleFor(v => v.ThoiGianCaLamBatDau)
                .NotEmpty().WithMessage("Thời gian bắt đầu ca làm là bắt buộc.");

            RuleFor(v => v.ThoiGianCaLamKetThuc)
                .NotEmpty().WithMessage("Thời gian kết thúc ca làm là bắt buộc.")
                .GreaterThan(v => v.ThoiGianCaLamBatDau).WithMessage("Thời gian kết thúc phải sau thời gian bắt đầu.");

            RuleFor(v => v.SoGioTangCa)
                .NotEmpty().WithMessage("Số giờ tăng ca là bắt buộc.");

            RuleFor(v => v.HeSoLuongTangCa)
                .GreaterThan(0).WithMessage("Hệ số lương tăng ca phải lớn hơn 0.");

            RuleFor(v => v.TrangThaiDuyet)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Trạng thái duyệt không hợp lệ.");

            RuleFor(v => v.NguoiDuyet)
                .NotEmpty().WithMessage("Người duyệt là bắt buộc.");
        }
    }
}
