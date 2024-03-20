using FluentValidation;
using NhaMayThep.Application.PhiCongDoan.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Update
{
    public class UpdatePhiCongDoanCommandValidator : AbstractValidator<UpdatePhiCongDoanCommand>
    {
        public UpdatePhiCongDoanCommandValidator()
        {

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.PhanTramLuongDongBH)
                .NotNull().WithMessage("PhanTramLuongDongBH không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("PhanTramLuongDongBH phải lớn hoặc bằng 0");

            RuleFor(x => x.LuongDongBH)
                .NotNull().WithMessage("LuongDongBH không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongDongBH phải lớn 0");
        }
    }
}
