﻿using FluentValidation;

namespace NhaMayThep.Application.KhenThuong.CreateKhenThuong
{
    public class CreateKhenThuongCommandValidator : AbstractValidator<CreateKhenThuongCommand>
    {
        public CreateKhenThuongCommandValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().NotNull()
                .WithMessage("Mã số nhân viên không được để trống.");
            RuleFor(x => x.ChinhSachNhanSuID)
                .NotEmpty().NotNull()
                .WithMessage("Chính sách nhân sự không được để trống.");
            RuleFor(x => x.TongThuong)
                .NotEmpty().NotNull()
                .WithMessage("Tổng Thưởng không được để trống.");
        }
    }
}
