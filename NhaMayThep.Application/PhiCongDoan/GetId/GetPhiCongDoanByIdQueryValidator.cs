using FluentValidation;

namespace NhaMayThep.Application.PhiCongDoan.GetId
{
    public class GetPhiCongDoanByIdQueryValidator : AbstractValidator<GetPhiCongDoanByIdQuery>
    {
        public GetPhiCongDoanByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
