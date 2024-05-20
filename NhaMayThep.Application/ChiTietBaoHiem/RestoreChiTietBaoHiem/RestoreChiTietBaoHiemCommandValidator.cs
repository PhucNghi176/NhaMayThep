using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem
{
    public class RestoreChiTietBaoHiemCommandValidator : AbstractValidator<RestoreChiTietBaoHiemCommand>
    {
        public RestoreChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không thể bỏ trống");
        }
    }
}
