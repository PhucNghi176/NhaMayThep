using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByIdDeletedQueryValidator : AbstractValidator<GetThongTinGiamTruGiaCanhByIdDeletedQuery>
    {
        public GetThongTinGiamTruGiaCanhByIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id không được bỏ trống")
                .NotEmpty().WithMessage("Id không được rỗng");
        }
    }
}
