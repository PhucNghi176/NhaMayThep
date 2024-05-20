using FluentValidation;

namespace NhaMayThep.Application.LichSuNghiPhep.FilterLichSuNghiPhep
{
    public class FilterLichSuNghiPhepQueryValidator : AbstractValidator<FilterLichSuNghiPhepQuery>
    {
        public FilterLichSuNghiPhepQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageNumber không được để trống");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageSize không được để trống");
        }
    }
}
