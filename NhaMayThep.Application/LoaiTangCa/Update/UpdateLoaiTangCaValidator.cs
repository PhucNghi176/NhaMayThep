using FluentValidation;
using NhaMayThep.Application.LoaiTangCa.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaValidator : AbstractValidator<UpdateLoaiTangCaCommand>
    {
        public UpdateLoaiTangCaValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required.");

        }
    }
}
