using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByTinhTrangLamViec
{
    public class FilterByTinhTrangLamViecQueryValidator : AbstractValidator<FilterByTinhTrangLamViecQuery>
    {
        public FilterByTinhTrangLamViecQueryValidator() 
        {
            RuleFor(x => x.tinhtranglamviecID)
                .NotEmpty().NotNull()
                .WithMessage("Nhập ID tình trạng làm việc cần tìm.");
            RuleFor(x => x.pageSize).NotEmpty().NotNull()
                .WithMessage("Nhập số lượng trong 1 trang.");
            RuleFor(x => x.pageNumber).NotEmpty().NotNull()
                .WithMessage("Nhập số trang.");
        }
    }
}
