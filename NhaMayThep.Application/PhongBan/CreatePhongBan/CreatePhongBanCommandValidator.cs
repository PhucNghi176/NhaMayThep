using FluentValidation;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandValidator : AbstractValidator<CreatePhongBanCommand>
    {
        public CreatePhongBanCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require");
        }
    }
}
