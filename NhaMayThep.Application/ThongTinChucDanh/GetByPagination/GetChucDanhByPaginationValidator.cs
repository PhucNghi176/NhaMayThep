using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucDanh.GetByPagination
{
    public class GetChucDanhByPaginationValidator : AbstractValidator<GetChucDanhByPaginationQuery>
    {
        public GetChucDanhByPaginationValidator()
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
