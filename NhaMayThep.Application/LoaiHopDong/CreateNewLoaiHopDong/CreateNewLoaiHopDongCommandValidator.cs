using FluentValidation;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommandValidator : AbstractValidator<CreateNewLoaiHopDongCommand>
    {
        public CreateNewLoaiHopDongCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.TenHopDong).NotEmpty().NotNull().WithMessage("Ten hop dong must not be null or empty");
        }
    }
}
