using FluentValidation;

namespace NhaMayThep.Application.LuongThoiGian.Filter
{
    public class FilterLuongThoiGianQueryValidator : AbstractValidator<FilterLuongThoiGIanQuery>
    {
        public FilterLuongThoiGianQueryValidator()
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
