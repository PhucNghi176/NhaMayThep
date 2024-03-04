using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem
{
    public class RestoreChiTietBaoHiemCommandValidator: AbstractValidator<RestoreChiTietBaoHiemCommand>
    {
        public RestoreChiTietBaoHiemCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không thể bỏ trống");
        }
    }
}
