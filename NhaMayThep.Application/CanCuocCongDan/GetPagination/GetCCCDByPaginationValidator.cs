using FluentValidation;

namespace NhaMayThep.Application.CanCuocCongDan.GetPagination
{
    public class GetCCCDByPaginationValidator : AbstractValidator<GetCCCDByPaginationQuery>
    {
        public GetCCCDByPaginationValidator()
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
