using FluentValidation;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommandValidator : AbstractValidator<DeleteCapBacLuongCommand>
    {
        public DeleteCapBacLuongCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã cấp bậc lương không được để trống")
                .NotNull().WithMessage("Mã cấp bậc lương không được rỗng");
        }
    }
}
