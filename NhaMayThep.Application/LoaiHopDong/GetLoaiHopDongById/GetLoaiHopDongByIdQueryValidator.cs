using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.GetLoaiHopDongById
{
    public class GetLoaiHopDongByIdQueryValidator : AbstractValidator<GetLoaiHopDongByIdQuery>
    {
        public GetLoaiHopDongByIdQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id must not empty or null");
        }
    }
}
