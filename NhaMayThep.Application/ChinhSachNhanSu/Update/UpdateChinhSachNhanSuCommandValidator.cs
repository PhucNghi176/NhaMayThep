using FluentValidation;
using NhaMapThep.Domain.Common.Enum;
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
                .Must(x => Enum.GetNames(typeof(LoaiHinhThuc)).Contains(x))
                .WithMessage("Invalid value for Loai Hinh Thuc. It should be either KiLuat or KhenThuong");
            });


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

            RuleFor(x => x.NoiDung)
                .MaximumLength(200).WithMessage("Maximum length is 200");

        }
    }
}
