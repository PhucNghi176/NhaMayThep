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
                .NotNull().WithMessage("Id không được bỏ trống")
                .NotEmpty().WithMessage("Id không được rỗng");
        }
    }
}
