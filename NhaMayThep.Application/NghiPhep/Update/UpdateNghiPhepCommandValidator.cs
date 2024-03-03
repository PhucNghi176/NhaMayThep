using FluentValidation;
using NhaMayThep.Application.NghiPhep.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommandValidator : AbstractValidator<UpdateNghiPhepCommand>
    {
        public UpdateNghiPhepCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

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
