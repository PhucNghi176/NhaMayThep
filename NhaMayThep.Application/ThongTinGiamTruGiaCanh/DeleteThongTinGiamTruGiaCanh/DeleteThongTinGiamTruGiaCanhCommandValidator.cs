﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommandValidator: AbstractValidator<DeleteThongTinGiamTruGiaCanhCommand>
    {
        public DeleteThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id không được bỏ trống")
               .NotNull().WithMessage("Id khong6 được rỗng")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Id không đúng định dạng");
        }
    }
}
