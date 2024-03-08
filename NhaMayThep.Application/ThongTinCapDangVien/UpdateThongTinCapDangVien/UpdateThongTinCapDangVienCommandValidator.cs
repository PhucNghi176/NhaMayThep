using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien
{
    public class UpdateThongTinCapDangVienCommandValidator : AbstractValidator<UpdateThongTinCapDangVienCommand>
    {
        public UpdateThongTinCapDangVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã cấp đảng viên không được để trống")
                .NotNull().WithMessage("Mã cấp đảng viên không được rỗng");
            RuleFor(x => x.TenCapDangVien)
                .NotEmpty().WithMessage("Tên cấp đảng viên không được để trống")
                .NotNull().WithMessage("Tên cấp đảng viên không được rỗng");
            RuleFor(x => x.CapDangVien)
                .NotEmpty().WithMessage("Thông tin cấp đảng viên không được để trống")
                .NotNull().WithMessage("Thông tin cấp đảng viên không được rỗng");
        }
    }
}
