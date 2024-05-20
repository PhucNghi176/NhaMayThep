using FluentValidation;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommandValidator : AbstractValidator<CreateDonViCongTacCommand>
    {
        public CreateDonViCongTacCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên không được để trống.");

        }
    }
}
