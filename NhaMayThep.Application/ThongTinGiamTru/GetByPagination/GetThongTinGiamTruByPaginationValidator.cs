﻿using FluentValidation;
using NhaMayThep.Application.ThongTinGiamTru.GetByPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetByPagination
{
    public class GetThongTinGiamTruByPaginationValidator : AbstractValidator<GetThongTinGiamTruByPaginationQuery>
    {
        public GetThongTinGiamTruByPaginationValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.PageSize).NotEmpty()
                .NotNull()
                .WithMessage("PageSize không được null hoặc để trống");

            RuleFor(x => x.PageNumber).NotEmpty()
                .NotNull()
                .WithMessage("PageNumber không được null hoặc để trống");
        }
    }
}
