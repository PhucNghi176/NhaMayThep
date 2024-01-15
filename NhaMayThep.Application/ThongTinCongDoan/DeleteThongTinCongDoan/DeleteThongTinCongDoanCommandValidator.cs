
using FluentValidation;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommandValidator : AbstractValidator<DeleteThongTinCongDoanCommand>
    {
        public DeleteThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty")
                .NotNull().WithMessage("Id must not be null")
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Invalid Id Format");
        }
    }
}
