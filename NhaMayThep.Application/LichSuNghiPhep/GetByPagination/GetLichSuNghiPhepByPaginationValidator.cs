using FluentValidation;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByPagination
{
    public class GetLichSuNghiPhepByPaginationValidator : AbstractValidator<GetLichSuNghiPhepByPaginationQuery>
    {
        public GetLichSuNghiPhepByPaginationValidator()
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
