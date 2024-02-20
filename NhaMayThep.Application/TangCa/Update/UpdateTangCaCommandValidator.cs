using FluentValidation;
using NhaMayThep.Application.TangCa.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Update
{
    public class UpdateTangCaCommandValidator : AbstractValidator<UpdateTangCaCommand>
    {
        public UpdateTangCaCommandValidator()
        {
            RuleFor(x => x.SoSanPhamLamThem)
                .NotEmpty().WithMessage("SoSanPhamLamThem không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("SoSanPhamLamThem phải lớn hoặc bằng 0");
            RuleFor(x => x.SoGioLamThem)
                .NotEmpty().WithMessage("SoGioLamThem không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("SoSanPhamLamThem phải lớn hoặc bằng 0");
            RuleFor(x => x.LuongSanPham)
                .NotEmpty().WithMessage("LuongSanPham không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("LuongSanPham phải lớn hoặc bằng 0");
            RuleFor(x => x.LuongCongNhat)
                .NotEmpty().WithMessage("LuongCongNhat không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("LuongCongNhat phải lớn hoặc bằng 0");
        }
    }
}
