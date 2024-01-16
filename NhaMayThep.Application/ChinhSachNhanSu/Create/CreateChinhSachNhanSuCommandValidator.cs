using FluentValidation;
using NhaMapThep.Domain.Common.Enum;
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
                .Must(x => Enum.GetNames(typeof(LoaiHinhThuc)).Contains(x))
                .WithMessage("Invalid value for Loai Hinh Thuc. It should be either KiLuat or KhenThuong");

            When(x => x.LoaiHinhThuc == LoaiHinhThuc.KhenThuong.ToString(), () =>
            {
                RuleFor(x => x.MucDo)
                    .NotEmpty().WithMessage("Muc Do is Required")
                    .Must(x => Enum.GetNames(typeof(KhenThuong)).Contains(x))
                    .WithMessage("Invalid Muc Do value for KhenThuong");
            });

            When(x => x.LoaiHinhThuc == LoaiHinhThuc.KiLuat.ToString(), () =>
            {
                RuleFor(x => x.MucDo)
                    .NotEmpty().WithMessage("Muc Do is Required")
                    .Must(x => Enum.GetNames(typeof(KiLuat)).Contains(x))
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
