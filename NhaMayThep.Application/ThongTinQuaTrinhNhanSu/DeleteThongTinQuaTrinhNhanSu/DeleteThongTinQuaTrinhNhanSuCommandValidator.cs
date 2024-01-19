using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.DeleteThongTinQuaTrinhNhanSu
{
    public class DeleteThongTinQuaTrinhNhanSuCommandValidator : AbstractValidator<DeleteThongTinQuaTrinhNhanSuCommand>
    {
        public DeleteThongTinQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require");
        }
    }
}
