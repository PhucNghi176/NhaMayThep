using FluentValidation;

namespace NhaMayThep.Application.LoaiTangCa.GetId
{
    public class GetLoaiTangCaByIdQueryValidator : AbstractValidator<GetLoaiTangCaByIdQuery>
    {
        public GetLoaiTangCaByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID is required");
        }
    }
}
