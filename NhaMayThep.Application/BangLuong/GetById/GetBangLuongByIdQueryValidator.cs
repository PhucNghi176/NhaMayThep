using FluentValidation;

namespace NhaMayThep.Application.BangLuong.GetById
{
    public class GetBangLuongByIdQueryValidator : AbstractValidator<GetBangLuongByIdQuery>
    {
        public GetBangLuongByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID is required");
        }
    }
}
