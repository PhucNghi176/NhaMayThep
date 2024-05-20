using FluentValidation;

namespace NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien
{
    public class UpdateThongTinCapDangVienCommandValidator : AbstractValidator<UpdateThongTinCapDangVienCommand>
    {
        public UpdateThongTinCapDangVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã cấp đảng viên không được để trống")
                .NotNull().WithMessage("Mã cấp đảng viên không được rỗng");
            RuleFor(x => x.TenCapDangVien)
                .NotEmpty().WithMessage("Tên cấp đảng viên không được để trống")
                .NotNull().WithMessage("Tên cấp đảng viên không được rỗng");
        }
    }
}
