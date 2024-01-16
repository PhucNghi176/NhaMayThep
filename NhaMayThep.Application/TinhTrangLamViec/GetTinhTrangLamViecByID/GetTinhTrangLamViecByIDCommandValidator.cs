using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDCommandValidator : AbstractValidator<GetTinhTrangLamViecByIDCommand>
    {
        public GetTinhTrangLamViecByIDCommandValidator() 
        {
            RuleFor(x => x.id)
                .NotNull().WithMessage("Id không được null.");
        }
    }
}
