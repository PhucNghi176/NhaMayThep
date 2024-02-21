using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh
{
    public class RestoreThongTinGiamTruGiaCanhCommandValidator: AbstractValidator<RestoreThongTinGiamTruGiaCanhCommand>
    {
        public RestoreThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Id không được bỏ trống")
               .NotNull().WithMessage("Id không được rỗng");        }
    }
}
