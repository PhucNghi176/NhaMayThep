using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllPagination
{
    public class GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQueryValidator: AbstractValidator<GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery>
    {
        public GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQueryValidator()
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
