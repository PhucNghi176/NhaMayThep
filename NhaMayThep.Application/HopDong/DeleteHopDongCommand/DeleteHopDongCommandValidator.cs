using FluentValidation;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommandValidator : AbstractValidator<DeleteHopDongCommand>
    {
        public DeleteHopDongCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not empty");
        }
    }
}
