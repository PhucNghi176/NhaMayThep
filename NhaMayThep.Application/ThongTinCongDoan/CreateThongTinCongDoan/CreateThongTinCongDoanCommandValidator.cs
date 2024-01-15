using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandValidator: AbstractValidator<CreateThongTinCongDoanCommand>
    {
        public CreateThongTinCongDoanCommandValidator() 
        {
            RuleFor(x => x.NhanVienID)
                .NotEmpty().WithMessage("NhanVienID must not be empty")
                .NotNull().WithMessage("NhanVienID must not be null")
                .Must(x => Guid.TryParseExact(x,"N",out _)).WithMessage("The NhanVienID is not correct");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("ThuKyCongDoan must be either true or false");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("NgayGiaNhap cannot be in the future"); ;
        }
    }
}
