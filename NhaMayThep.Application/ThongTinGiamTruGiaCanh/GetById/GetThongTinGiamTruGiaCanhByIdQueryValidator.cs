using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById
{
    public class GetThongTinGiamTruGiaCanhByIdQueryValidator : AbstractValidator<GetThongTinGiamTruGiaCanhByIdQuery>
    {
        public GetThongTinGiamTruGiaCanhByIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Id không đúng định dạng");
        }
    }
}
