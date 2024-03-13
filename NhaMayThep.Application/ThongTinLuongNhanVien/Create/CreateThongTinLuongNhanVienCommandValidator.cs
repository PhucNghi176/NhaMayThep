﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommandValidator : AbstractValidator<CreateThongTinLuongNhanVienCommand>
    {
        public CreateThongTinLuongNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.MaSoHopDong)
                .NotEmpty().WithMessage("Ma So Hop Dong is Required");

            RuleFor(x => x.Loai)
                .NotEmpty().WithMessage("Loai is Required")
                .Must(x => x == "TangLuong" || x == "GiamLuong")
                .WithMessage("Nhập liệu không hợp lệ, Nên là Tăng Lương hoặc Giám Lương"); ;

            RuleFor(x => x.LuongCu)
                .NotEmpty().WithMessage("Luong Cu is Required")
                .GreaterThan(0).WithMessage("Luong Cu must be greater than 0");

            RuleFor(x => x.LuongMoi)
                .NotEmpty().WithMessage("Luong Hien Tai is Required")
                .GreaterThan(0).WithMessage("Luong Hien Tai must be greater than 0");

            RuleFor(x => x.NgayHieuLuc)
                .NotEmpty().WithMessage("Ngay Hien Luc is Required");

        }
    }
}
