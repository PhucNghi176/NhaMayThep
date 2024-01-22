using FluentValidation;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommandValidator : AbstractValidator<UpdateLoaiHopDongCommand>
    {
        public UpdateLoaiHopDongCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be null or empty");
            RuleFor(x => x.TenHopDong).NotNull().NotEmpty().WithMessage("Ten hop dong must not be null or empty");
        }
    }
}
