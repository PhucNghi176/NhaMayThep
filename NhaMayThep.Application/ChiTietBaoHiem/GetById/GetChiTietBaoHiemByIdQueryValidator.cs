using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetById
{
    public class GetChiTietBaoHiemByIdQueryValidator: AbstractValidator<GetChiTietBaoHiemByIdQuery>
    {
        public GetChiTietBaoHiemByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được bỏ trống");
        }
    }
}
