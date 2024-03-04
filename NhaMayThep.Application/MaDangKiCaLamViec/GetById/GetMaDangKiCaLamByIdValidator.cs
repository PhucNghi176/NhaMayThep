using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.GetById
{
    public class GetMaDangKiCaLamByIdValidator : AbstractValidator<GetMaDangKiCaLamByIdQuery>
    {
        public GetMaDangKiCaLamByIdValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Id Không Được Để Trống.");
        }
    }
}
