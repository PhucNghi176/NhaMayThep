using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllPagination
{
    public class GetAllThongTinCongDoanPaginationQueryValidator : AbstractValidator<GetAllThongTinCongDoanPaginationQuery>
    {
        public GetAllThongTinCongDoanPaginationQueryValidator()
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
