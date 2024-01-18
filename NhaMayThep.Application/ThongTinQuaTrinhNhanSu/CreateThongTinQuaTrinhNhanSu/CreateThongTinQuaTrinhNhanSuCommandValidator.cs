using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu
{
    public class CreateThongTinQuaTrinhNhanSuCommandValidator : AbstractValidator<CreateThongTinQuaTrinhNhanSuCommand>
    {
        public CreateThongTinQuaTrinhNhanSuCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require");
        }
    }
}
