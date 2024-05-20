using FluentValidation;

namespace NhaMayThep.Application.KyLuat.GetByPagination
{
    public class GetKyLuatByPaginationValidator : AbstractValidator<GetKyLuatByPaginationQuery>
    {
        public GetKyLuatByPaginationValidator()
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
