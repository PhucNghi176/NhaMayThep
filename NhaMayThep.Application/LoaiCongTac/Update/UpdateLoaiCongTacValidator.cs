using FluentValidation;

namespace NhaMayThep.Application.LoaiCongTac.Update
{
    public class UpdateLoaiCongTacValidator : AbstractValidator<UpdateLoaiCongTacCommad>
    {
        public UpdateLoaiCongTacValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name Không Được Để Trống.")
            .MaximumLength(100).WithMessage("Name Chỉ Được Tối Đa 100 Kí Tự");
        }
    }
}
