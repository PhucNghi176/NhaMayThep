using FluentValidation;

namespace NhaMayThep.Application.KyLuat.DeleteKyLuat
{
    public class DeleteKyLuatCommandValidator : AbstractValidator<DeleteKyLuatCommand>
    {
        public DeleteKyLuatCommandValidator()
        {
            ConfigureValidasionRules();
        }
        public void ConfigureValidasionRules()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty()
                .WithMessage("ID không được để trống.");
        }

    }
}
