using FluentValidation;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandValidator : AbstractValidator<DeletePhongBanCommand>
    {
        public DeletePhongBanCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require");
        }
    }
}
