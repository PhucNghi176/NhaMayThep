using FluentValidation;
using NhaMayThep.Application.TangCa.GetId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.GetId
{
    public class GetTangCaByIdQueryValidator : AbstractValidator<GetTangCaByIdQuery>
    {
        public GetTangCaByIdQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
