using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Update
{
    public class UpdateMaDangKiCaLamValidator : AbstractValidator<UpdateMaDangKiCaLamCommand>
    {
        public UpdateMaDangKiCaLamValidator () 
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Id Không Được Để Trống.");

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
