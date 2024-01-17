using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Delete
{
    public class DeleteKhenThuongCommandValidator : AbstractValidator<DeleteKhenThuongCommand>
    {
        public DeleteKhenThuongCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is Required");
        }
    }
}
