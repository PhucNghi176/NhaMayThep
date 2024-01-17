using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Create
{
    public class CreateKhenThuongCommandValidator : AbstractValidator<CreateKhenThuongCommand>
    {
        public CreateKhenThuongCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.HinhThucKhenThuong)
                .NotEmpty().WithMessage("Hinh Thuc Khen Thuong is Required");

            RuleFor(x => x.LoaiKhenThuong)
                .NotEmpty().WithMessage("Loai Khen Thuong is Required");

            RuleFor(x => x.TenDotKhenThuong)
                .NotEmpty().WithMessage("Ten Dot KhenThuong is Required");

            RuleFor(x => x.NgayKhenThuong)
                .NotEmpty().WithMessage("Ngay Khen Thuong is Required");

            RuleFor(x => x.TongGiaTri)
                .NotEmpty().WithMessage("Tong Gia Tri is Required")
                .GreaterThan(0).WithMessage("Tong Gia Tri must be greater than 0");

            RuleFor(x => x.DonViApDung)
                .NotEmpty().WithMessage("Don Vi Ap Dung is Required");
        }
    }
}
