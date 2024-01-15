using FluentValidation;
using NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandValidator: AbstractValidator<UpdateThongTinCongDoanCommand>
    {
        public UpdateThongTinCongDoanCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty")
                .NotNull().WithMessage("Id must not be null")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Invalid Id Format");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("ThuKyCongDoan must be either true or false");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayGiaNhap cannot be in the future");

        }
    }
}
