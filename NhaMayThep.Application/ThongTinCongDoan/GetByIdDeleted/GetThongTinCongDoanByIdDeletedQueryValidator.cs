using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByIdDeleted
{
    public class GetThongTinCongDoanByIdDeletedQueryValidator: AbstractValidator<GetThongTinCongDoanByIdDeletedQuery>
    {
        public GetThongTinCongDoanByIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã thông tin công đoàn không đúng định dạng");
        }
    }
}
