using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.ChangePasswordNhanVIen
{
    public class ChangePasswordNhanVienvValidator : AbstractValidator<ChangePasswordNhanVienCommand>
    {
        public ChangePasswordNhanVienvValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Mật khẩu cũ không được để trống");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Mật khẩu mới không được để trống");
            // mat khau moi phai nhieu hon 6 ki tu
            RuleFor(x => x.NewPassword).MinimumLength(6).WithMessage("Mật khẩu mới phải nhiều hơn 6 kí tự");
        }
    }
}
