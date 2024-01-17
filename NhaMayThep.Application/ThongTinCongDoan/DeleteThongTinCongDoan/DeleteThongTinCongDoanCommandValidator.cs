﻿
using FluentValidation;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommandValidator : AbstractValidator<DeleteThongTinCongDoanCommand>
    {
        public DeleteThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã thông tin công đoàn không đúng định dạng");
        }
    }
}
