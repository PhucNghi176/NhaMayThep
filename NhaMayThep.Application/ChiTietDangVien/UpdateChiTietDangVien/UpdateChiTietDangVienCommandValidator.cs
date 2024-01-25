using FluentValidation;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien
{
    public class UpdateChiTietDangVienCommandValidator : AbstractValidator<UpdateChiTietDangVienCommand>
    {
        public UpdateChiTietDangVienCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.DangVienID)
                .MaximumLength(450).WithMessage("DangVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.DonViCongTacID)
                .GreaterThanOrEqualTo(1).WithMessage("DonViCongTacID phải lớn hơn hoặc bằng 1.");
        }
    }
}
