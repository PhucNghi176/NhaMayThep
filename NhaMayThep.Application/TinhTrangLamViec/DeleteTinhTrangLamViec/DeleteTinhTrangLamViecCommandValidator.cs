using FluentValidation;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommandValidator : AbstractValidator<DeleteTinhTrangLamViecCommand>
    {
        public DeleteTinhTrangLamViecCommandValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id không được để trống!!!");
        }
    }
}
