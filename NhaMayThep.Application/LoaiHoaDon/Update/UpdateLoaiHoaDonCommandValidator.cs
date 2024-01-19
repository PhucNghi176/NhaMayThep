using FluentValidation;

namespace NhaMayThep.Application.LoaiHoaDon.Update
{
    public class UpdateLoaiHoaDonCommandValidator : AbstractValidator<UpdateLoaiHoaDonCommand>
    {
        public UpdateLoaiHoaDonCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id Không Được Để Trống.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
