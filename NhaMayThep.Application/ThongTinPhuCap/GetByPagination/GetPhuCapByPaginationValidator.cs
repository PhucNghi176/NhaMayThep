using FluentValidation;

namespace NhaMayThep.Application.ThongTinPhuCap.GetByPagination
{
    public class GetPhuCapByPaginationValidator : AbstractValidator<GetPhuCapByPaginationQuery>
    {
        public GetPhuCapByPaginationValidator()
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
