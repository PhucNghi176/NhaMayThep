using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Filter
{
    public class FilterLuongCongNhatQueryValidator : AbstractValidator<FilterLuongCongNhatQuery>
    {
        public FilterLuongCongNhatQueryValidator()
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
