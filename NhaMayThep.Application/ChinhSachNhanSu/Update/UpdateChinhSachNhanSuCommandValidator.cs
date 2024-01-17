using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommandValidator : AbstractValidator<UpdateChinhSachNhanSuCommand>
    {
        public UpdateChinhSachNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            When(x => !string.IsNullOrEmpty(x.LoaiHinhThuc) , () =>
            {
                RuleFor(x => x.LoaiHinhThuc)
                .Must(x => x == "KiLuat" || x == "KhenThuong")
                .WithMessage("Invalid value for Loai Hinh Thuc. It should be either KiLuat or KhenThuong");
            });

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

            RuleFor(x => x.NoiDung)
                .MaximumLength(200).WithMessage("Maximum length is 200");

        }
    }
}
