using FluentValidation;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommandValidator : AbstractValidator<UpdateThongTinDangVienCommand>
    {
        public UpdateThongTinDangVienCommandValidator()
        {
            RuleFor(x => x.ID)
               .NotEmpty().WithMessage("ID không được để trống.");

            RuleFor(x => x.DonViCongTacID)
                .GreaterThanOrEqualTo(1).WithMessage("DonViCongTacID phải lớn hơn hoặc bằng 1.");

            RuleFor(x => x.NgayVaoDang)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("NgayVaoDang không được là ngày trong tương lai.");

            RuleFor(x => x.CapDangVien)
                .NotEmpty().WithMessage("CapDangVien không được để trống.");
        }
    }
}
