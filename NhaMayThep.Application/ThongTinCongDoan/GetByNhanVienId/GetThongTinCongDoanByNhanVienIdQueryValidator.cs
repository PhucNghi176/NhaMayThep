using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQueryValidator: AbstractValidator<GetThongTinCongDoanByNhanVienIdQuery>
    {
        public GetThongTinCongDoanByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id must not be empty")
               .NotNull().WithMessage("Id must not be null")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("The ID is not correct");
        }
    }
}
