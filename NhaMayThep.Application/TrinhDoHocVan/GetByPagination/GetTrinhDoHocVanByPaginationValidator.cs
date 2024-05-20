using FluentValidation;

namespace NhaMayThep.Application.TrinhDoHocVan.GetByPagination
{
    public class GetTrinhDoHocVanByPaginationValidator : AbstractValidator<GetTrinhDoHocVanByPaginationQuery>
    {
        public GetTrinhDoHocVanByPaginationValidator()
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
