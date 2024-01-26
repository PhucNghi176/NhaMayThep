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
            .NotEmpty().WithMessage("ID không để trống");

            RuleFor(cmd => cmd.LoaiNghiPhepID)
                .NotNull().WithMessage("Leave không để trống.");

            RuleFor(cmd => cmd.TongSoGio)
                .GreaterThan(0).WithMessage("Tổng số giờ phải là số dương.");

            RuleFor(cmd => cmd.SoGioDaNghiPhep)
                .GreaterThanOrEqualTo(0).WithMessage("Số giờ đã nghĩ phép không được âm.")
                .LessThanOrEqualTo(cmd => cmd.TongSoGio).WithMessage("Số giờ đã nghĩ không được lớn hơn tổng số giờ.");

            RuleFor(cmd => cmd.SoGioConLai)
                .GreaterThanOrEqualTo(0).WithMessage("số giờ còn lại không âm.")
                .Must((cmd, soGioConLai) => soGioConLai == cmd.TongSoGio - cmd.SoGioDaNghiPhep)
                .WithMessage("Số giờ còn lại phải bằng hoặc khác tổng số giờ và số giờ nghỉ phép" +
                ".");

            RuleFor(cmd => cmd.NamHieuLuc)
                .InclusiveBetween(DateTime.Now.Year - 5, DateTime.Now.Year + 5)
                .WithMessage("Năm hiệu lực phải trong khoảng hợp lí");
        }
    }
}
