using FluentValidation;

namespace NhaMayThep.Application.DangKiCaLam.GetId
{
    public class GetDangKiCaLamByIdQueryValidator : AbstractValidator<GetDangKiCaLamByIdQuery>
    {
        public GetDangKiCaLamByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(query => query.Id).NotEmpty().WithMessage("MaCaLamViec khong de trong");
        }
    }
}
