using FluentValidation;

namespace NhaMayThep.Application.LoaiCongTac.Create
{
    public class CreateLoaiCongTacCommandValidator : AbstractValidator<CreateLoaiCongTacCommand>
    {
        public CreateLoaiCongTacCommandValidator()
        {
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
