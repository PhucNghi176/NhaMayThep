using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh
{
    public class RestoreThongTinGiamTruGiaCanhCommandValidator : AbstractValidator<RestoreThongTinGiamTruGiaCanhCommand>
    {
        public RestoreThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id không được bỏ trống")
               .NotNull().WithMessage("Id không được rỗng");
        }
    }
}
