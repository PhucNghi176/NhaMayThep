using FluentValidation;
using NhaMayThep.Application.NghiPhep.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Create
{
    public class CreateNghiPhepCommandValidator : AbstractValidator<CreateNghiPhepCommand>
    {
        public CreateNghiPhepCommandValidator()
        {
            RuleFor(x => x.LuongNghiPhep)
                .NotEmpty().WithMessage("LuongNghiPhep không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("LuongNghiPhep phải lớn hoặc bằng 0");

            RuleFor(x => x.LoaiNghiPhepID)
                .NotEmpty().WithMessage("LoaiNghiPhepID không được để trống.");

            RuleFor(x => x.SoGioNghiPhep)
                .NotEmpty().WithMessage("SoGioNghiPhep không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("SoGioNghiPhep phải lớn 0");
            RuleFor(x => x.KhoanTruLuong)
                .NotEmpty().WithMessage("KhoanTruLuong không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("KhoanTruLuong phải lớn 0");
        }
    }
}
