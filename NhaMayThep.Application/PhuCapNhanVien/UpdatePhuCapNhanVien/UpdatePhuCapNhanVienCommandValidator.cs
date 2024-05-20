using FluentValidation;

namespace NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien
{
    public class UpdatePhuCapNhanVienCommandValidator : AbstractValidator<UpdatePhuCapNhanVienCommand>
    {
        public UpdatePhuCapNhanVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã phụ cấp nhân viên không được để trống");
            RuleFor(x => x.PhuCap)
                .NotEmpty().WithMessage("Phụ cấp nhân viên không được để trống");
        }
    }
}
