using FluentValidation;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommandValidator : AbstractValidator<CreateLoaiHoaDonCommand>
    {
        public CreateLoaiHoaDonCommandValidator()
        {

            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
