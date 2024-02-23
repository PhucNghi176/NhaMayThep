using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Delete
{
    public class DeleteMaDangKiCaLamValidator : AbstractValidator<DeleteMaDangKiCaLamCommand>
    {
        public DeleteMaDangKiCaLamValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Id Không Được Để Trống.");
        }
    }
}
