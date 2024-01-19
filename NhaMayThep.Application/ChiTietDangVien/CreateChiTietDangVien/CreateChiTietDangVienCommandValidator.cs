using FluentValidation;
using NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.CreateChiTietDangVien
{
    public class CreateChiTietDangVienCommandValidator : AbstractValidator<CreateChiTietDangVienCommand>
    {
        public CreateChiTietDangVienCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.DangVienID)
                .NotEmpty().WithMessage("DangVienID không được để trống.")
                .MaximumLength(450).WithMessage("DangVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.DonViCongTacID)
                .NotEmpty().WithMessage("DonViCongTacID không được để trống.")
                .GreaterThanOrEqualTo(1).WithMessage("DonViCongTacID phải lớn hơn hoặc bằng 1.");
        }
    }
}
