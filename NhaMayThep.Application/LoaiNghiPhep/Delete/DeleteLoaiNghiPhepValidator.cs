using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepValidator : AbstractValidator<DeleteLoaiNghiPhepCommand>
    {
        public DeleteLoaiNghiPhepValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
           
        }
    }
}