using FluentValidation;

namespace NhaMayThep.Application.PhongBan.GetSinglePhongBan
{
    public class GetPhongBanQueryValidator : AbstractValidator<GetPhongBanQuery>
    {
        public GetPhongBanQueryValidator()
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
