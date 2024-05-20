using FluentValidation;

namespace NhaMayThep.Application.LuongCongNhat.GetId
{
    public class GetLuongCongNhatByIdQueryValidator : AbstractValidator<GetLuongCongNhatByIdQuery>
    {
        public GetLuongCongNhatByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
