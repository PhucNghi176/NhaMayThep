using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Update
{
    public class UpdateLoaiCongTacValidator : AbstractValidator<UpdateLoaiCongTacCommad>
    {
        public UpdateLoaiCongTacValidator() 
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be at most 100 characters.");
        }
    }
}
