using FluentValidation;

namespace NhaMayThep.Application.TinhTrangLamViec.GetByPagination
{
    public class GetTinhTrangLamViecByPaginationValidator : AbstractValidator<GetTinhTrangLamViecByPaginationQuery>
    {
        public GetTinhTrangLamViecByPaginationValidator()
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
