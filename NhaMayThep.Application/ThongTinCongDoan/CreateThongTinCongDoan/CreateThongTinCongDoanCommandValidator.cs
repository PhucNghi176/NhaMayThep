﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandValidator: AbstractValidator<CreateThongTinCongDoanCommand>
    {
        public CreateThongTinCongDoanCommandValidator() 
        {
            RuleFor(x => x.NhanVienID)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống")
                .NotNull().WithMessage("Mã nhân viên không được null")
                .Must(x => Guid.TryParseExact(x,"N",out _)).WithMessage("Mã nhân viên không đúng định dạn");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("Sai định dạng dữ liệu thư ký công đoàn");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("Ngày gia nhập không thể lớn hơn ngày hiện tại"); ;
        }
    }
}
