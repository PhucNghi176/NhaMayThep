using FluentValidation;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByPagination
{
    public class GetLichSuCongTacNhanVienByPaginationValidator : AbstractValidator<GetLichSuCongTacNhanVienByPaginationQuery>
    {
        public GetLichSuCongTacNhanVienByPaginationValidator()
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
