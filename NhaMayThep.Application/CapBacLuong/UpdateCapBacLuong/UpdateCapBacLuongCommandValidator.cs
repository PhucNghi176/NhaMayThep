using FluentValidation;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommandValidator : AbstractValidator<UpdateCapBacLuongCommand>
    {
        public UpdateCapBacLuongCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã cấp bậc lương không được để trống")
                .NotNull().WithMessage("Mã cấp bậc lương không được rỗng");
            RuleFor(x => x.TenCapBac)
                .NotEmpty().WithMessage("Tên cấp bậc không được để trống")
                .NotNull().WithMessage("Tên cấp bậc không được rỗng");
            RuleFor(x => x.HeSoLuong)
                .NotEmpty().WithMessage("Hệ số lương không được để trống")
                .NotNull().WithMessage("Hệ số lương không được rỗng");
        }
    }
}
