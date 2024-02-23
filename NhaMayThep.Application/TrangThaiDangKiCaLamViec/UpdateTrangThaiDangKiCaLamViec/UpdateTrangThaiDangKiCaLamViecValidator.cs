using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec
{
    public class UpdateTrangThaiDangKiCaLamViecValidator : AbstractValidator<UpdateTrangThaiDangKiCaLamViecCommand>
    {
        public UpdateTrangThaiDangKiCaLamViecValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
