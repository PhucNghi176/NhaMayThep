using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdQueryValidator : AbstractValidator<GetThongTinGiamTruGiaCanhByNhanVienIdQuery>
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id không được bỏ trống")
                .NotEmpty().WithMessage("Id không được rỗng");
        }
    }
}
