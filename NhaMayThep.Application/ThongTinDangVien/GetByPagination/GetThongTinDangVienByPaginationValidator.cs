using FluentValidation;

namespace NhaMayThep.Application.ThongTinDangVien.GetByPagination
{
    public class GetThongTinDangVienByPaginationValidator : AbstractValidator<GetThongTinDangVienByPaginationQuery>
    {
        public GetThongTinDangVienByPaginationValidator()
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
