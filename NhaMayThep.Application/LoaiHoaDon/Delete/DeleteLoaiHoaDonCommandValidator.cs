using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommandValidator : AbstractValidator<DeleteLoaiHoaDonCommand>
    {
        public DeleteLoaiHoaDonCommandValidator() 
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
