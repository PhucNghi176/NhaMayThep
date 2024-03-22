﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.FilterBaoHiem
{
    public class FilterBaoHiemQueryValidator: AbstractValidator<FilterBaoHiemQuery>
    {
        public FilterBaoHiemQueryValidator() 
        {
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageSize không được bỏ trống");
            RuleFor(x => x.PageNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageNumber không được bỏ trống");
        }
    }
}