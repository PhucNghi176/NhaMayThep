using FluentValidation;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommadValidator : AbstractValidator<DeleteLoaiCongTacCommad>
    {
        public DeleteLoaiCongTacCommadValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
        }
    }
}
