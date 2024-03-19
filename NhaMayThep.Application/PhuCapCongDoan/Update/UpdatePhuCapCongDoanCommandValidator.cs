using FluentValidation;
using NhaMayThep.Application.PhuCapCongDoan.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.Update
{
    public class UpdatePhuCapCongDoanCommandValidator : AbstractValidator<UpdatePhuCapCongDoanCommand>
    {
        public UpdatePhuCapCongDoanCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID không được để trống");

            RuleFor(v => v.SoLuongDoanVien)
                .NotNull().WithMessage("SoLuongDoanVien không được trống")
                .GreaterThan(0).WithMessage("SoLuongDoanVien phải lớn hơn 0");

            RuleFor(v => v.HeSoPhuCap)
                .NotNull().WithMessage("HeSoPhuCap không được trống")
                .GreaterThanOrEqualTo(0).WithMessage("HeSoPhuCap phải lớn hơn hoặc bằng 0");

            RuleFor(v => v.DonVi)
                .NotNull().WithMessage("DonVi không được trống");
        }
    }
}
