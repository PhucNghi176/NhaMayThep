using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPagination
{
    public class GetAllThongTinGiamTruGiaCanhPaginationQueryValidator : AbstractValidator<GetAllThongTinGiamTruGiaCanhPaginationQuery>
    {
        public GetAllThongTinGiamTruGiaCanhPaginationQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.PageSize).NotEmpty()
                .NotNull()
                .WithMessage("PageSize không được null hoặc để trống");

            RuleFor(x => x.PageNumber).NotEmpty()
                .NotNull()
                .WithMessage("PageNumber không được null hoặc để trống");
        }
    }
}
