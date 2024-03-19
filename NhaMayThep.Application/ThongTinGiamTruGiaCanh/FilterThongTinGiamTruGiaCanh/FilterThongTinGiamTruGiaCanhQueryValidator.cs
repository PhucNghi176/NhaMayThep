﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh
{
    public class FilterThongTinGiamTruGiaCanhQueryValidator: AbstractValidator<FilterThongTinGiamTruGiaCanhQuery>
    {
        public FilterThongTinGiamTruGiaCanhQueryValidator()
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
