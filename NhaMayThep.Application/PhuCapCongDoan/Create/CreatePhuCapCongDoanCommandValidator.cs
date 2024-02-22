using FluentValidation;
using NhaMayThep.Application.PhuCapCongDoan.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.Create
{
    public class CreatePhuCapCongDoanCommandValidator : AbstractValidator<CreatePhuCapCongDoanCommand>
    {
        public CreatePhuCapCongDoanCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
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
