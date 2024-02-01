﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllDeleted
{
    public class GetAllThongTinGiamTruGiaCanhDeletedQueryValidator : AbstractValidator<GetAllThongTinGiamTruGiaCanhDeletedQuery>
    {
        public GetAllThongTinGiamTruGiaCanhDeletedQueryValidator()
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
