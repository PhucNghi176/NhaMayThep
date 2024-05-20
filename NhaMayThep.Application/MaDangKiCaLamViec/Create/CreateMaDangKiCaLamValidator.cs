using FluentValidation;

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
                .NotEmpty().WithMessage("ThoiGianCaLamKetThuc Không Được Để Trống.");
        }
    }
}
