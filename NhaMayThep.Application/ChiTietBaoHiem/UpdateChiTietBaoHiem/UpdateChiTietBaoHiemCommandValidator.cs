using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.UpdateChiTietBaoHiem
{
    public class UpdateChiTietBaoHiemCommandValidator: AbstractValidator<UpdateChiTietBaoHiemCommand>
    {
        public UpdateChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được phép bỏ trống");
        }
    }
}
