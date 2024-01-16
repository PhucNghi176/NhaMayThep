using FluentValidation;
using NhaMapThep.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommandValidator : AbstractValidator<DeleteChinhSachNhanSuCommand>
    {
        public DeleteChinhSachNhanSuCommandValidator()
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
