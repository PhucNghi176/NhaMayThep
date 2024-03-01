using FluentValidation;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllPagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted
{
    public class GetAllPaginationDeletedChiTietBaoHiemQueryValidator : AbstractValidator<GetAllPaginationDeletedChiTietBaoHiemQuery>
    {
        public GetAllPaginationDeletedChiTietBaoHiemQueryValidator()
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
