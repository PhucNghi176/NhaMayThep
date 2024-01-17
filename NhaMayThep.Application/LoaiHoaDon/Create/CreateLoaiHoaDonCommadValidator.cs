using FluentValidation;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommadValidator : AbstractValidator<CreateLoaiHoaDonCommand>
    {
        public CreateLoaiHoaDonCommadValidator()
        {

            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
