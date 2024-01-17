using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByIdDeletedQueryValidator: AbstractValidator<GetThongTinGiamTruGiaCanhByIdDeletedQuery>
    {
        public GetThongTinGiamTruGiaCanhByIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
              .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Id không đúng định dạng");
        }
    }
}
