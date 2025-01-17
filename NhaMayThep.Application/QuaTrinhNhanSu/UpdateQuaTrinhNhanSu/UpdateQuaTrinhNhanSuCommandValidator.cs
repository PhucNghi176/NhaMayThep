﻿using FluentValidation;

namespace NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu
{
    public class UpdateQuaTrinhNhanSuCommandValidator : AbstractValidator<UpdateQuaTrinhNhanSuCommand>
    {
        public UpdateQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotEmpty().WithMessage("ID is require");

            RuleFor(v => v.ChucVuID)
                .NotNull().WithMessage("ChucVuId is require");

            RuleFor(v => v.ChucDanhID)
                .NotNull().WithMessage("ChucDanhID is require");

            RuleFor(v => v.LoaiQuaTrinhID)
                .NotNull().WithMessage("LoaiQuaTrinhID is require");

            RuleFor(v => v.PhongBanID)
                .NotNull().WithMessage("PhongBanID is require");

            RuleFor(v => v.NgayKetThuc)
                .GreaterThan(x => x.NgayBatDau).WithMessage("NgayKetThuc is not valid");
        }
    }
}
