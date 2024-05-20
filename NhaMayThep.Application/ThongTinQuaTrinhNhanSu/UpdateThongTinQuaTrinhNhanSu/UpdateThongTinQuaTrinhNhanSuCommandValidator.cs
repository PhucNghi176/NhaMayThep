using FluentValidation;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.UpdateThongTinQuaTrinhNhanSu
{
    public class UpdateThongTinQuaTrinhNhanSuCommandValidator : AbstractValidator<UpdateThongTinQuaTrinhNhanSuCommand>
    {
        public UpdateThongTinQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID is require");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is require");
        }
    }
}
