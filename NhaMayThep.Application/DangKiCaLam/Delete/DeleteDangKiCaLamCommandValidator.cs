using FluentValidation;
using NhaMayThep.Application.DangKiTangCa.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommandValidator : AbstractValidator<DeleteDangKiCaLamCommand>
    {
        public DeleteDangKiCaLamCommandValidator()
        {
            RuleFor(x => x.MaCaLamViec)
              .NotEmpty()
              .WithMessage("Id không được để trống ");
        }
    }
}
