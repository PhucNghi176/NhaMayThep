using FluentValidation;

namespace NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien
{
    public class CreateThongTinCapDangVienCommandValidator : AbstractValidator<CreateThongTinCapDangVienCommand>
    {
        public CreateThongTinCapDangVienCommandValidator()
        {
            RuleFor(x => x.TenCapDangVien)
                .NotEmpty().WithMessage("Tên cấp đảng viên không được để trống.")
                .NotNull().WithMessage("Tên cấp đảng viên không được để rỗng.");
        }
    }
}
