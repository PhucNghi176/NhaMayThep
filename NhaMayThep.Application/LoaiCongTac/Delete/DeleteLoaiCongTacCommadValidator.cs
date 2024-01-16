using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommadValidator : AbstractValidator<DeleteLoaiCongTacCommad>
    {
       public DeleteLoaiCongTacCommadValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
