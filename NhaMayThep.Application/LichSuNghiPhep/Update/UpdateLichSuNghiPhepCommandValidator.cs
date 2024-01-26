using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Update
{
    public class UpdateLichSuNghiPhepCommandValidator : AbstractValidator<UpdateLichSuNghiPhepCommand>
    {
        public UpdateLichSuNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(command => command.MaSoNhanVien)
            .NotEmpty().WithMessage("MaSoNhanVien không để trống.");

            RuleFor(command => command.LoaiNghiPhepID)
                .GreaterThan(0).WithMessage("LoaiNghiPhepID lớn hơn 0.");

            RuleFor(command => command.NgayBatDau)
                .NotEmpty().WithMessage("NgayBatDau is required.")
                .LessThanOrEqualTo(command => command.NgayKetThuc).WithMessage("NgayBatDau phải bằng hoặc ngang NgayKetThuc.");

            RuleFor(command => command.LyDo)
                .NotEmpty().WithMessage("LyDo không để trống.");

            RuleFor(command => command.NguoiDuyet)
                .NotEmpty().WithMessage("NguoiDuyet không để trống.");
        }
    }
}
