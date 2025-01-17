﻿using FluentValidation;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandValidator : AbstractValidator<UpdateKhaiBaoTangLuongCommand>
    {
        public UpdateKhaiBaoTangLuongCommandValidator()
        {

            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.PhanTramTang)
                    .NotNull().WithMessage("PhanTramTang không được để trống.")
                    .GreaterThanOrEqualTo(0).WithMessage("PhanTramTang phải lớn 0");

            RuleFor(x => x.NgayApDung)
                .NotNull().WithMessage("NgayApDung không được để trống.");

            RuleFor(x => x.LyDo)
                .NotNull().WithMessage("LyDo không được để trống.");
        }
    }
}
