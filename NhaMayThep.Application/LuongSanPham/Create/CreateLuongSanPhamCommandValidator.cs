using FluentValidation;
using NhaMayThep.Application.LuongSanPham.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommandValidator : AbstractValidator<CreateLuongSanPhamCommand>
    {
        public CreateLuongSanPhamCommandValidator()
        {




            RuleFor(x => x.SoSanPhamLam)
                .NotNull().WithMessage("SoSanPhamLam không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoSanPhamLam phải lớn hoặc bằng 0");

            RuleFor(x => x.MucSanPhamID)
                .NotNull().WithMessage("MucSanPhamID không được để trống.");

            RuleFor(x => x.TongLuong)
                .NotNull().WithMessage("TongLuong không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0");
        }
    }
}