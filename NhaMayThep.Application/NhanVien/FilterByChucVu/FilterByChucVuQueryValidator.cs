using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByChucVu
{
    public class FilterByChucVuQueryValidator : AbstractValidator<FilterByChucVuQuery>
    {
        public FilterByChucVuQueryValidator() 
        {
            RuleFor(x => x.chucvuID)
                .NotEmpty().NotNull()
                .WithMessage("Nhập ID chức vụ cần tìm.");
            RuleFor(x => x.pageSize).NotEmpty().NotNull()
                .WithMessage("Nhập số lượng trong 1 trang.");
            RuleFor(x => x.pageNumber).NotEmpty().NotNull()
                .WithMessage("Nhập số trang.");
        }
    }
}
