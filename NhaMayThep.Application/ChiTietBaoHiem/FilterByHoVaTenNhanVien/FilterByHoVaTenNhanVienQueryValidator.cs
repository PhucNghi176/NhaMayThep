﻿using FluentValidation;
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
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageNumber không được bỏ trống")
                .Must(x => x > 0).WithMessage("PageNumber phải lớn hơn 0");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageSize không được bỏ trống")
                .Must(x => x > 0).WithMessage("PageSize phải lớn hơn 0");
        }
    }
}
