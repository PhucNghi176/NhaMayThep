using FluentValidation;

namespace NhaMayThep.Application.LoaiHopDong.DeleteLoaiHopDong
{
    public class DeleteLoaiHopDongCommandValidator : AbstractValidator<DeleteLoaiHopDongCommand>
    {
        public DeleteLoaiHopDongCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be empty or null");
        }
    }
}
