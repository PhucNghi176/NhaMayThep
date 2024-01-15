using FluentValidation;
using NhaMapThep.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandValidator : AbstractValidator<UpdateThongTinLuongNhanVienCommand>
    {
        public UpdateThongTinLuongNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.Loai)
                .Must(x => Enum.GetNames(typeof(Loai)).Contains(x))
                .WithMessage("Invalid value for Loai. It should be either TangLuong or GiamLuong"); ;

            RuleFor(x => x.LuongCu)
                .GreaterThan(0).WithMessage("Luong Cu must be greater than 0");

            RuleFor(x => x.LuongHienTai)
                .GreaterThan(0).WithMessage("Luong Hien Tai must be greater than 0");
        }
    }
}
