using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterChiTietBaoHiem
{
    public class FilterChiTietBaoHiemQueryValidator : AbstractValidator<FilterChiTietBaoHiemQuery>
    {
        public FilterChiTietBaoHiemQueryValidator()
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
