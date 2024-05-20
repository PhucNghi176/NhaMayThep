using FluentValidation;

namespace NhaMayThep.Application.LoaiNghiPhep.GetById
{
    public class GetLoaiNghiPhepValidator : AbstractValidator<GetLoaiNghiPhepByIdQuery>
    {
        public GetLoaiNghiPhepValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ID không để trống");
        }
    }
}
