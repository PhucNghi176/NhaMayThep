using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNgayNghiPhepCommandValidator : AbstractValidator<UpdateChiTietNgayNghiPhepCommand>
    {
        public UpdateChiTietNgayNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {

            RuleFor(cmd => cmd.Id)
            .NotEmpty().WithMessage("ID is required..");

            RuleFor(cmd => cmd.LoaiNghiPhepID)
                .NotNull().WithMessage("Leave type is required.");

            RuleFor(cmd => cmd.TongSoGio)
                .GreaterThan(0).WithMessage("Total hours must be a positive number.");

            RuleFor(cmd => cmd.SoGioDaNghiPhep)
                .GreaterThanOrEqualTo(0).WithMessage("Hours already taken cannot be negative.")
                .LessThanOrEqualTo(cmd => cmd.TongSoGio).WithMessage("Hours already taken cannot exceed total hours.");

            RuleFor(cmd => cmd.SoGioConLai)
                .GreaterThanOrEqualTo(0).WithMessage("Remaining hours cannot be negative.")
                .Must((cmd, soGioConLai) => soGioConLai == cmd.TongSoGio - cmd.SoGioDaNghiPhep)
                .WithMessage("Remaining hours must be equal to the difference between total hours and hours already taken.");

            RuleFor(cmd => cmd.NamHieuLuc)
                .InclusiveBetween(DateTime.Now.Year - 5, DateTime.Now.Year + 5)
                .WithMessage("Effective year must be within a reasonable range from the current year");
        }
    }
}
