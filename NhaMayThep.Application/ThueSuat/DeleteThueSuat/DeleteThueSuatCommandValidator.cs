using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.DeleteThueSuat
{
    public class DeleteThueSuatCommandValidator : AbstractValidator<DeleteThueSuatCommand>
    {
        public DeleteThueSuatCommandValidator() 
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống");
        }
    }
}
