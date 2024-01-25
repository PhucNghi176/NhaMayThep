using FluentValidation;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommandValidator : AbstractValidator<CreateKhaiBaoTangLuongCommand>
    {
        public CreateKhaiBaoTangLuongCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.PhanTramTang)
                .NotEmpty().WithMessage("PhanTramTang không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("PhanTramTang phải lớn 0");

            RuleFor(x => x.NgayApDung)
                .NotEmpty().WithMessage("NgayApDung không được để trống.");

            RuleFor(x => x.LyDo)
                .NotEmpty().WithMessage("LyDo không được để trống.");
        }
    }
}
