using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommandValidator : AbstractValidator<CreateKhaiBaoTangLuongCommand>
    {
        public CreateKhaiBaoTangLuongCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Ma So Nhan Vien is Required");

            RuleFor(x => x.PhanTramTang)
                .NotEmpty().WithMessage("Phan Tram is Required")
                .ExclusiveBetween(0, 1).WithMessage("PhanTram must between 0 to 1");

            RuleFor(x => x.NgayApDung)
                .NotEmpty().WithMessage("Ngay Ap Dung is Required")
                .Must(x => x >= DateTime.Now).WithMessage("Ngay Ap Dung must be equal or greater than current date");

            RuleFor(x => x.LyDo)
                .NotEmpty().WithMessage("Ly do is Required")
                .MaximumLength(200).WithMessage("Maximum length is 200");

        }
    }
}
