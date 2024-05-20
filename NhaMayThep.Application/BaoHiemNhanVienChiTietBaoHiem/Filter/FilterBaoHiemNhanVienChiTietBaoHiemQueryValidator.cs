using FluentValidation;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Filter
{
    public class FilterBaoHiemNhanVienChiTietBaoHiemQueryValidator : AbstractValidator<FilterBaoHiemNhanVienChiTietBaoHiemQuery>
    {
        public FilterBaoHiemNhanVienChiTietBaoHiemQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Number không được bỏ trống");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("Page Size không được bỏ trống");
        }
    }
}
