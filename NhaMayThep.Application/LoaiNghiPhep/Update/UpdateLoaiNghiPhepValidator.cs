using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepValidator : AbstractValidator<UpdateLoaiNghiPhepCommand>
    {
        public UpdateLoaiNghiPhepValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required.");

        }
    }
}