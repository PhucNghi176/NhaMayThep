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
            .NotEmpty().WithMessage("MaSoNhanVien is required.");

            RuleFor(command => command.LoaiNghiPhepID)
                .GreaterThan(0).WithMessage("LoaiNghiPhepID must be greater than 0.");

            RuleFor(command => command.NgayBatDau)
                .NotEmpty().WithMessage("NgayBatDau is required.")
                .LessThanOrEqualTo(command => command.NgayKetThuc).WithMessage("NgayBatDau must be less than or equal to NgayKetThuc.");

            RuleFor(command => command.LyDo)
                .NotEmpty().WithMessage("LyDo is required.");

            RuleFor(command => command.NguoiDuyet)
                .NotEmpty().WithMessage("NguoiDuyet is required.");
        }
    }
}
