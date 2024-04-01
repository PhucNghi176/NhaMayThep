﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Create
{
    public class CreateBaoHiemNhanVienChiTietBaoHiemCommandValidator: AbstractValidator<CreateBaoHiemNhanVienChiTietBaoHiemCommand>
    {
        public CreateBaoHiemNhanVienChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.MaCTBH)
                .NotNull()
                .NotEmpty()
                .WithMessage("Mã bảo hiểm nhân viên không thể bỏ trống");
            RuleFor(x => x.MaBHNV)
               .NotNull()
               .NotEmpty()
               .WithMessage("Mã bảo hiểm nhân viên không thể bỏ trống");
        }
    }
}