using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.CreatePhuCapNhanVien
{
    public class CreatePhuCapNhanVienCommandValidator : AbstractValidator<CreatePhuCapNhanVienCommand>
    {
        public CreatePhuCapNhanVienCommandValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã số nhân viên không được để trống.");

            RuleFor(x => x.PhuCap)
                .NotEmpty().WithMessage("Phụ cấp nhân viên không được để trống.");
        }
    }
}
