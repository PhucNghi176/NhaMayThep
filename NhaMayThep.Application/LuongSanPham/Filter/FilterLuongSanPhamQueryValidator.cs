using FluentValidation;

namespace NhaMayThep.Application.LuongSanPham.Filter
{
    public class FilterLuongSanPhamQueryValidator : AbstractValidator<FilterLuongSanPhamQuery>
    {
        public FilterLuongSanPhamQueryValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.PageNo)
                .NotEmpty().WithMessage("Số trang không được trống")
                .NotNull().WithMessage("Số trang không được rỗng");

            RuleFor(x => x.PageSize)
                .NotEmpty().WithMessage("Số item trong trang không được để trống")
                .NotNull().WithMessage("Số item trong trang không được rỗng");
        }
    }
}
