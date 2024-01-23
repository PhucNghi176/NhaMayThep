using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDQueryValidator : AbstractValidator<GetTinhTrangLamViecByIDQuery>
    {
        public GetTinhTrangLamViecByIDQueryValidator() 
        {
            RuleFor(x => x.id)
                .NotNull().WithMessage("Id không được để trống.");
        }
    }
}
