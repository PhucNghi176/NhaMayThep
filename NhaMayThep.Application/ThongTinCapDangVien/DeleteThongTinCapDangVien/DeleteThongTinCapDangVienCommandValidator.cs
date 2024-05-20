using FluentValidation;

namespace NhaMayThep.Application.ThongTinCapDangVien.DeleteThongTinCapDangVien
{
    public class DeleteThongTinCapDangVienCommandValidator : AbstractValidator<DeleteThongTinCapDangVienCommand>
    {
        public DeleteThongTinCapDangVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin cấp đảng viên không được để trống")
                .NotNull().WithMessage("Mã thông tin cấp đảng viên không được rỗng");
        }
    }
}
