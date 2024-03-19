using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien
{
    public class CreateThongTinDangVienCommandValidator : AbstractValidator<CreateThongTinDangVienCommand>
    {
        public CreateThongTinDangVienCommandValidator()
        {


            RuleFor(x => x.NhanVienID)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.DonViCongTacID)
                .NotEmpty().WithMessage("DonViCongTacID không được để trống.")
                .GreaterThanOrEqualTo(1).WithMessage("DonViCongTacID phải lớn hơn hoặc bằng 1.");

            RuleFor(x => x.NgayVaoDang)
                .NotEmpty().WithMessage("NgayVaoDang không được để trống.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("NgayVaoDang không được là ngày trong tương lai.");

            RuleFor(x => x.CapDangVien)
                .NotEmpty().WithMessage("CapDangVien không được để trống.");

            RuleFor(x => x.ChucVuDang)
                .NotEmpty().WithMessage("ChucVuDang không được để trống.");

            RuleFor(x => x.TrinhDoChinhTri)
                .NotEmpty().WithMessage("TrinhDoChinhTri không được để trống.");
        }
    }
}
