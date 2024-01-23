using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.UpdateThongTinQuaTrinhNhanSu
{
    public class UpdateThongTinQuaTrinhNhanSuCommandValidator : AbstractValidator<UpdateThongTinQuaTrinhNhanSuCommand>
    {
        public UpdateThongTinQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID is require");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is require");
        }
    }
}
