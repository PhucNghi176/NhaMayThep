using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap
{
    public class CreateNewChucDanhCommandValidator : AbstractValidator<CreateNewPhuCapCommand>
    {
        public CreateNewChucDanhCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.TenPhuCap).NotEmpty().NotNull().WithMessage("Ten phu cap must not be null or empty");
            RuleFor(x => x.PhanTramPhuCap).NotEmpty().NotNull().WithMessage("Phan tram phu cap must not be null or empty");
        }
    }
}
