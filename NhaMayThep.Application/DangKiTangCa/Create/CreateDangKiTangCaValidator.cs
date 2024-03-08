using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Create
{
    public class CreateDangKiTangCaValidator : AbstractValidator<CreateDangKiTangCaCommand>
    {
        public CreateDangKiTangCaValidator()
        {
            RuleFor(v => v.MaSoNhanVien).NotEmpty().WithMessage("MaSoNhanVien không để trống.");

            RuleFor(v => v.NgayLamTangCa).NotEmpty().WithMessage("NgayLamTangCa không để trống");

            RuleFor(v => v.CaDangKi).GreaterThan(0).WithMessage("CaDangKi phải lớn hơn 0.");

            RuleFor(v => v.LiDoTangCa).NotEmpty().WithMessage("LiDoTangCa không để trống.");

            RuleFor(v => v.ThoiGianCaLamBatDau).NotEmpty().WithMessage("ThoiGianCaLamBatDau không để trống.");

            RuleFor(v => v.ThoiGianCaLamKetThuc).NotEmpty().WithMessage("ThoiGianCaLamKetThuc không để trống.")
                .GreaterThan(v => v.ThoiGianCaLamBatDau).WithMessage("ThoiGianCaLamKetThuc phải sau ThoiGianCaLamBatDau.");


            RuleFor(v => v.HeSoLuongTangCa).GreaterThan(0).WithMessage("HeSoLuongTangCa phải lớn hơn 0.");

            RuleFor(v => v.TrangThaiDuyet).GreaterThanOrEqualTo(0).WithMessage("TrangThaiDuyet không để trống.");
            RuleFor(v => v.NguoiDuyet).NotEmpty().WithMessage("NguoiDuyet is required.");

        }
    }
}
