using FluentValidation;
using NhaMayThep.Application.LuongThoiGian.UpdateLuongThoiGian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien
{
    public class UpdatePhuCapNhanVienCommandValidator : AbstractValidator<UpdatePhuCapNhanVienCommand>
    {
        public UpdatePhuCapNhanVienCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã phụ cấp nhân viên không được để trống");
            RuleFor(x => x.PhuCap)
                .NotEmpty().WithMessage("Phụ cấp nhân viên không được để trống");
        }
    }
}
