using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Create
{
    public class CreateMaDangKiCaLamValidator : AbstractValidator<CreateMaDangKiCaLamCommand>
    {
        public CreateMaDangKiCaLamValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name Không Được Để Trống.");

            RuleFor(command => command.ThoiGianCaLamBatDau)
                .NotEmpty().WithMessage("ThoiGianCaLamBatDau Không Được Để Trống.");

            RuleFor(command => command.ThoiGianCaLamKetThuc)
                .NotEmpty().WithMessage("ThoiGianCaLamKetThuc Không Được Để Trống.")
                .Must((command, ketThuc) => ketThuc > command.ThoiGianCaLamBatDau)
                .WithMessage("ThoiGianCaLamKetThuc phải lớn hơn ThoiGianCaLamBatDau.");
        }
    }
}
