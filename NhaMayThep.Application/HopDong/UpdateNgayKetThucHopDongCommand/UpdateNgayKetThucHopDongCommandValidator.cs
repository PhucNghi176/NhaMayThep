using FluentValidation;

namespace NhaMayThep.Application.HopDong.UpdateNgayKetThucHopDongCommand
{
    public class UpdateNgayKetThucHopDongCommandValidator : AbstractValidator<UpdateNgayKetThucHopDongCommand>
    {
        public UpdateNgayKetThucHopDongCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id không được để trống");
        }
    }
}
