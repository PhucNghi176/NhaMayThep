using FluentValidation;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommandValidator : AbstractValidator<UpdateChinhSachNhanSuCommand>
    {
        public UpdateChinhSachNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID không được trống");

            RuleFor(v => v.Name)
               .NotEmpty().WithMessage("Name không được trống");

            RuleFor(v => v.MucDo)
                .NotEmpty().WithMessage("MucDo không được trống");

            RuleFor(v => v.NgayHieuLuc)
                .NotNull().WithMessage("NgayHieuLuc không được trống");
        }
    }
}
