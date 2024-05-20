using FluentValidation;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetById
{
    public class GetChiTietNgayNghiPhepByIdQueryValidator : AbstractValidator<GetChiTietNgayNghiPhepByIdQuery>
    {
        public GetChiTietNgayNghiPhepByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(query => query.Id)
            .NotEmpty().WithMessage("ID không để trống.");
        }
    }
}