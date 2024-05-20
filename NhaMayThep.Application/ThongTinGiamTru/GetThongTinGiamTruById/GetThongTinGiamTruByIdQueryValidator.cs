using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdQueryValidator : AbstractValidator<GetThongTinGiamTruByIdQuery>
    {
        public GetThongTinGiamTruByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("ID is null");
        }
    }
}
