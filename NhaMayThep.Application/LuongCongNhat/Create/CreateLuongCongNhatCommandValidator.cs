﻿using FluentValidation;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Create
{
    public class CreateLuongCongNhatCommandValidator : AbstractValidator<CreateLuongCongNhatCommand>
    {
        public CreateLuongCongNhatCommandValidator()
        {




            RuleFor(x => x.SoGioLam)
                .NotNull().WithMessage("SoGioLam không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoGioLam phải lớn 0");

            RuleFor(x => x.Luong1Gio)
                .NotNull().WithMessage("Luong1Gio không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("Luong1Gio phải lớn 0"); 

            RuleFor(x => x.TongLuong)
                .NotNull().WithMessage("TongLuong không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0"); 
        }
    }
}