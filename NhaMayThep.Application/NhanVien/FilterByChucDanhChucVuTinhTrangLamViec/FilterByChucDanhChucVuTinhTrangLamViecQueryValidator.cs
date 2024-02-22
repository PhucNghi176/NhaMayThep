using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByChucDanhChucVuTinhTrangLamViec
{
    public class FilterByChucDanhChucVuTinhTrangLamViecQueryValidator : AbstractValidator<FilterByChucDanhChucVuTinhTrangLamViecQuery>
    {
        public FilterByChucDanhChucVuTinhTrangLamViecQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .NotEmpty().NotNull()
                .WithMessage("Nhập số trang.");
            RuleFor(x => x.PageSize)
                .NotEmpty().NotNull()
                .WithMessage("Nhập kích cỡ trang.");
            RuleFor(x => x.ChucVuHoacTinhTrangLamViec)
                .NotEmpty().NotNull()
                .WithMessage("Nhập chức danh hoặc chức vụ hoặc tình trạng làm việc.");
        }
    }
}
