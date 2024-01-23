using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Update
{
    public class UpdateLuongCongNhatCommandValidator : AbstractValidator<UpdateLuongCongNhatCommand>
    {
        public UpdateLuongCongNhatCommandValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("MaSoNhanVien không được để trống.")
                .MaximumLength(450).WithMessage("MaSoNhanVien không vượt quá 450 kí tự.");

            RuleFor(x => x.SoGioLam)
                .NotEmpty().WithMessage("SoGioLam không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("SoGioLam phải lớn 0");

            RuleFor(x => x.Luong1Gio)
                .NotEmpty().WithMessage("CapDangVien không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("Luong1Gio phải lớn 0"); ;

            RuleFor(x => x.TongLuong)
                .NotEmpty().WithMessage("TongLuong không được để trống.")
                .LessThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0"); ;
        }
    }
}
