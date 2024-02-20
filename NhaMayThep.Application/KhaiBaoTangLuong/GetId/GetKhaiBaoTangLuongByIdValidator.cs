﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetId
{
    public class GetKhaiBaoTangLuongByIdQueryValidator : AbstractValidator<GetKhaiBaoTangLuongByIdQuery>
    {
        public GetKhaiBaoTangLuongByIdQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}