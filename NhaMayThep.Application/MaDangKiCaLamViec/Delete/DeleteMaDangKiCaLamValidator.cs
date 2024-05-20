using FluentValidation;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Delete
{
    public class DeleteMaDangKiCaLamValidator : AbstractValidator<DeleteMaDangKiCaLamCommand>
    {
        public DeleteMaDangKiCaLamValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Id Không Được Để Trống.");
        }
    }
}
