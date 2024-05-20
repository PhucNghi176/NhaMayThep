using FluentValidation;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommandValidator : AbstractValidator<DeleteChinhSachNhanSuCommand>
    {
        public DeleteChinhSachNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
