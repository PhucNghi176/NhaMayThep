using FluentValidation;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeletedPagination
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQueryValidator : AbstractValidator<GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery>
    {
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
               .NotNull()
               .NotEmpty()
               .WithMessage("PageNumber không được bỏ trống")
               .Must(x => x > 0).WithMessage("PageNumber phải lớn hơn 0");
            RuleFor(x => x.PageSize)
                .NotNull()
                .NotEmpty()
                .WithMessage("PageSize không được bỏ trống")
                .Must(x => x > 0).WithMessage("PageSize phải lớn hơn 0");
        }
    }
}
