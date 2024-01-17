using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Create
{
    public class CreateKyLuatCommandValidator : AbstractValidator<CreateKyLuatCommand>
    {
        public CreateKyLuatCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.HinhThucKyLuat)
                .NotEmpty().WithMessage("Hinh Thuc Ki Luat is Required");

            RuleFor(x => x.LoaiKyLuat)
                .NotEmpty().WithMessage("Loai Ki Luat is Required");

            RuleFor(x => x.TenDotKyLuat)
                .NotEmpty().WithMessage("Ten Dot Ki Luat is Required");

            RuleFor(x => x.NgayKiLuat)
                .NotEmpty().WithMessage("Ngay Ki Luat is Required");

            RuleFor(x => x.TongPhat)
                .NotEmpty().WithMessage("Tong Phat is Required")
                .GreaterThan(0).WithMessage("Tong Phat must be greater than 0");

            RuleFor(x => x.DonViApDung)
                .NotEmpty().WithMessage("Don Vi Ap Dung is Required");
        }
    }
}
