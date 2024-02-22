using FluentValidation;
using NhaMayThep.Application.TangCa.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Create
{
    public class CreateTangCaCommandValidator : AbstractValidator<CreateTangCaCommand>
    {
        public CreateTangCaCommandValidator()
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
