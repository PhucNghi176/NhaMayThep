using FluentValidation;
using NhaMayThep.Application.LuongSanPham.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommandValidator : AbstractValidator<UpdateLuongSanPhamCommand>
    {
        public UpdateLuongSanPhamCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.SoSanPhamLam)
                .NotEmpty().WithMessage("SoSanPhamLam không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("SoSanPhamLam phải lớn hoặc bằng 0");

            RuleFor(x => x.MucSanPhamID)
                .NotEmpty().WithMessage("MucSanPhamID không được để trống.");

            RuleFor(x => x.TongLuong)
                .NotEmpty().WithMessage("TongLuong không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0"); 
        }
    }
}
