using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQueryValidator : AbstractValidator<GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery>
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id không được bỏ trống")
                .NotEmpty().WithMessage("Id không được rỗng");
        }
    }
}
