using FluentValidation;

namespace NhaMayThep.Application.BaoHiem.GetPaginationBaoHiem
{
    public class GetBaoHiemByPaginationValidator : AbstractValidator<GetBaoHiemByPagination>
    {
        public GetBaoHiemByPaginationValidator()
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
