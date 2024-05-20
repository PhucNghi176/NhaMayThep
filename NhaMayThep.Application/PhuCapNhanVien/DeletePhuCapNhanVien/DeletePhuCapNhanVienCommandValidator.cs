using FluentValidation;

namespace NhaMayThep.Application.PhuCapNhanVien.DeletePhuCapNhanVien
{
    public class DeletePhuCapNhanVienCommandValidator : AbstractValidator<DeletePhuCapNhanVienCommand>
    {
        public DeletePhuCapNhanVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã phụ cấp nhân viên không được để trống")
                .NotNull().WithMessage("Mã phụ cấp nhân viên không được rỗng");
        }
    }
}
