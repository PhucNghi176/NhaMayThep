using FluentValidation;


namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommandValidator : AbstractValidator<DeleteNghiPhepCommand>
    {
        public DeleteNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }
}
