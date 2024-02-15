using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommandValidator : AbstractValidator<DeleteLoaiTangCaCommand>
    {
        public DeleteLoaiTangCaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

        }
    }
}
