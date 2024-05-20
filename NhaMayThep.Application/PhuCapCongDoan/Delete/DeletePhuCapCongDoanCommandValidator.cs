using FluentValidation;

namespace NhaMayThep.Application.PhuCapCongDoan.Delete
{
    public class DeletePhuCapCongDoanCommandValidator : AbstractValidator<DeletePhuCapCongDoanCommand>
    {
        public DeletePhuCapCongDoanCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID không được để trống");
        }
    }
}
