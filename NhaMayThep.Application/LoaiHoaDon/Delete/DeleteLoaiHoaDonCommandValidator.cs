using FluentValidation;

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommandValidator : AbstractValidator<DeleteLoaiHoaDonCommand>
    {
        public DeleteLoaiHoaDonCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id Không Được Để Trống.");
        }
    }
}
