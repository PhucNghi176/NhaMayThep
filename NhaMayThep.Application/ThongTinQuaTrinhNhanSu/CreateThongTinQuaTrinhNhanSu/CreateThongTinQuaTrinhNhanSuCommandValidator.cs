using FluentValidation;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu
{
    public class CreateThongTinQuaTrinhNhanSuCommandValidator : AbstractValidator<CreateThongTinQuaTrinhNhanSuCommand>
    {
        public CreateThongTinQuaTrinhNhanSuCommandValidator()
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
