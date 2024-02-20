using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById
{
    public class GetThongTinGiamTruGiaCanhByIdQueryValidator : AbstractValidator<GetThongTinGiamTruGiaCanhByIdQuery>
    {
        public GetThongTinGiamTruGiaCanhByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id không được bỏ trống")
                .NotEmpty().WithMessage("Id không được rỗng");
        }
    }
}
