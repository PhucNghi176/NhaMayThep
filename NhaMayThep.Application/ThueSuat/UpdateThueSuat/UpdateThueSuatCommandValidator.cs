using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.UpdateThueSuat
{
    public class UpdateThueSuatCommandValidator : AbstractValidator<UpdateThueSuatCommand>
    {
        public UpdateThueSuatCommandValidator() 
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
