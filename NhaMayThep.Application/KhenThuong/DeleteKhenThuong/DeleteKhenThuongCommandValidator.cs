using FluentValidation;

namespace NhaMayThep.Application.KhenThuong.DeleteKhenThuong
{
    public class DeleteKhenThuongCommandValidator : AbstractValidator<DeleteKhenThuongCommand>
    {
        public DeleteKhenThuongCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống");
        }
    }
}
