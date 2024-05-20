using FluentValidation;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetById
{
    public class GetMaDangKiCaLamByIdValidator : AbstractValidator<GetMaDangKiCaLamByIdQuery>
    {
        public GetMaDangKiCaLamByIdValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Id Không Được Để Trống.");
        }
    }
}
