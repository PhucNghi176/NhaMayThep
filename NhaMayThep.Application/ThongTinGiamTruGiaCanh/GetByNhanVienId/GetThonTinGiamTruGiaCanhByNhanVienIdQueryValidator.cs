using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThonTinGiamTruGiaCanhByNhanVienIdQueryValidator : AbstractValidator<GetThonTinGiamTruGiaCanhByNhanVienIdQuery>
    {
        public GetThonTinGiamTruGiaCanhByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id must not be empty")
               .NotNull().WithMessage("Id must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");
        }
    }
}
