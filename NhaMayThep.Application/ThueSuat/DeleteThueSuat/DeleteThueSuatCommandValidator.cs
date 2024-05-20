using FluentValidation;

namespace NhaMayThep.Application.ThueSuat.DeleteThueSuat
{
    public class DeleteThueSuatCommandValidator : AbstractValidator<DeleteThueSuatCommand>
    {
        public DeleteThueSuatCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống");
        }
    }
}
