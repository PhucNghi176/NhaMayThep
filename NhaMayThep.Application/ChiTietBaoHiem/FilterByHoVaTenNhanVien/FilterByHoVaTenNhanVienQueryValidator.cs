using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterByHoVaTenNhanVienQueryValidator: AbstractValidator<FilterByHoVaTenNhanVienQuery>
    {
        public FilterByHoVaTenNhanVienQueryValidator()
        {
            RuleFor(x => x.HoVaTen)
                .NotNull()
                .NotEmpty()
                .WithMessage("Họ và tên không được bỏ trống");
        }
    }
}
