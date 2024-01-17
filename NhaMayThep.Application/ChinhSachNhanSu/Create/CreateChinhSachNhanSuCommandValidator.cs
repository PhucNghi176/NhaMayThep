using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommandValidator : AbstractValidator<CreateChinhSachNhanSuCommand>
    {
        public CreateChinhSachNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.LoaiHinhThuc)
                .NotEmpty().WithMessage("Loai Hinh Thuc is Required")
                .Must(x => x == "KhenThuong" || x == "KiLuat")
                .WithMessage("Invalid value for Loai Hinh Thuc. It should be either KiLuat or KhenThuong");

            When(x => x.LoaiHinhThuc == "KhenThuong", () =>
            {
                RuleFor(x => x.MucDo)
                    .NotEmpty().WithMessage("Muc Do is Required")
                    .Must(x => x == "TienThuong" || x == "GiayKhen" || x == "ThangTien" || x == "NgayNghi" || x == "QuaTang")
                    .WithMessage("Invalid Muc Do value for KhenThuong");
            });

            When(x => x.LoaiHinhThuc == "KiLuat", () =>
            {
                RuleFor(x => x.MucDo)
                    .NotEmpty().WithMessage("Muc Do is Required")
                    .Must(x => x == "KhienTrach" || x == "CanhCao" || x == "HaLuong" || x == "PhatTien" || x == "GiangChuc" || x == "CachChuc" || x == "BuocThoiViec")
                    .WithMessage("Invalid Muc Do value for KiLuat");
            });

            RuleFor(x => x.NgayHieuLuc)
                .NotEmpty().WithMessage("Ngay Hieu Luc is Required");

            RuleFor(x => x.NoiDung)
                .NotEmpty().WithMessage("Ly do is Required")
                .MaximumLength(200).WithMessage("Maximum length is 200");

        }
    }
}
