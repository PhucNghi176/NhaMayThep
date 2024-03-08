using FluentValidation;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaCommandValidator : AbstractValidator<DeleteDangKiTangCaCommand>
    {
        public DeleteDangKiTangCaCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id không được để trống ");
        }
    }
}
