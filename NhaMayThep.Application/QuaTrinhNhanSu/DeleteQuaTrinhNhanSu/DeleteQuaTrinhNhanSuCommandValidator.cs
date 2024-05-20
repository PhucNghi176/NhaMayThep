using FluentValidation;

namespace NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu
{
    public class DeleteQuaTrinhNhanSuCommandValidator : AbstractValidator<DeleteQuaTrinhNhanSuCommand>
    {
        public DeleteQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID is require");
        }
    }
}
