using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommandValidator : AbstractValidator<UpdateLoaiHopDongCommand>
    {
        public UpdateLoaiHopDongCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be null or empty");
            RuleFor(x => x.TenHopDong).NotNull().NotEmpty().WithMessage("Ten hop dong must not be null or empty");
        }
    }
}
