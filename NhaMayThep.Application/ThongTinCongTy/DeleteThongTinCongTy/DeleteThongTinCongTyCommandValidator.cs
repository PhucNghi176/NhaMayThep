using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommandValidator : AbstractValidator<DeleteThongTinCongTyCommand>
    {
        public DeleteThongTinCongTyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã doanh nghiệp không được để trống")
                .NotNull().WithMessage("Mã doanh nghiệp không được rỗng");
        }
    }
}
