using FluentValidation;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien
{
    public class CreateThongTinCapDangVienCommandValidator : AbstractValidator<CreateThongTinCapDangVienCommand>
    {
        public CreateThongTinCapDangVienCommandValidator()
        {
            RuleFor(x => x.TenCapDangVien)
                .NotEmpty().WithMessage("Tên cấp đảng viên không được để trống.")
                .NotNull().WithMessage("Tên cấp đảng viên không được để rỗng.");
            RuleFor(x => x.CapDangVien)
                .NotEmpty().WithMessage("Cấp đảng viên không được để trống.")
                .NotNull().WithMessage("Cấp đảng viên không được để rỗng."); ;
        }
    }
}
