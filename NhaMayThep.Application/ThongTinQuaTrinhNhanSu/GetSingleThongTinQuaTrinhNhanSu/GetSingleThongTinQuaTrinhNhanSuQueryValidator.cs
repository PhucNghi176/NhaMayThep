using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu
{
    public class GetSingleThongTinQuaTrinhNhanSuQueryValidator : AbstractValidator<GetSingleThongTinQuaTrinhNhanSuQuery>
    {
        public GetSingleThongTinQuaTrinhNhanSuQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID is require");
        }
    }
}
