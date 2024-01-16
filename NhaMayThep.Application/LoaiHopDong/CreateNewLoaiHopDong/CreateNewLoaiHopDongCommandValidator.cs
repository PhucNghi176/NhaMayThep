using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommandValidator : AbstractValidator<CreateNewLoaiHopDongCommand>
    {
        public CreateNewLoaiHopDongCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.TenHopDong).NotEmpty().NotNull().WithMessage("Ten hop dong must not be null or empty");
        }
    }
}
