using FluentValidation;

namespace NhaMayThep.Application.TrinhDoHocVan.Delete
{
    public class DeleteTrinhDoHocVanCommandValidator : AbstractValidator<DeleteTrinhDoHocVanCommand>
    {
        public DeleteTrinhDoHocVanCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID là bắt buộc");
        }
    }
}
