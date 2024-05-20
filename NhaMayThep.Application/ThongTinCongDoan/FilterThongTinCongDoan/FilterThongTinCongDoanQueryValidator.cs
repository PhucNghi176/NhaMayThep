using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.FilterThongTinCongDoan
{
    public class FilterThongTinCongDoanQueryValidator : AbstractValidator<FilterThongTinCongDoanQuery>
    {
        public FilterThongTinCongDoanQueryValidator()
        {
            RuleFor(x => x.PageSize)
                .NotEmpty()
                   .NotNull()
                   .WithMessage("PageSize không được null hoặc để trống");
            RuleFor(x => x.PageNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("PageNumber không được null hoặc để trống");
        }
    }
}
