﻿using FluentValidation;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommandValidator : AbstractValidator<UpdateThongTinDangVienCommand>
    {
        public UpdateThongTinDangVienCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
               .NotEmpty().WithMessage("ID không được để trống.")
               .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.NgayVaoDang)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("NgayVaoDang không được là ngày trong tương lai.");

            RuleFor(x => x.CapDangVien)
                .NotEmpty().WithMessage("CapDangVien không được để trống.");
        }
    }
}