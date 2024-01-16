using FluentValidation;
using NhaMayThep.Application.LichSuCongTacNhanVien.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Update
{
    public class UpdateLoaiHoaDonCommandValidator : AbstractValidator<UpdateLoaiHoaDonCommand>
    {
        public UpdateLoaiHoaDonCommandValidator() 
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters.");
        }
    }
}
