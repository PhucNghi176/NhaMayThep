using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.UpdateChiTietBaoHiem
{
    public class UpdateChiTietBaoHiemCommandValidator : AbstractValidator<UpdateChiTietBaoHiemCommand>
    {
        public UpdateChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được phép bỏ trống");
        }
    }
}
