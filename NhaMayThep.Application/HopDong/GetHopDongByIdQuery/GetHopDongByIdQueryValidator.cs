using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.GetHopDongByIdQuery
{
    public class GetHopDongByIdQueryValidator : AbstractValidator<GetHopDongByIdQuery>
    {
        public GetHopDongByIdQueryValidator() 
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not null");
        }
    }
}
