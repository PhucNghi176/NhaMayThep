using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandValidator : AbstractValidator<UpdateKhaiBaoTangLuongCommand>
    {
        public UpdateKhaiBaoTangLuongCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {

            RuleFor(x => x.PhanTramTang)
                .ExclusiveBetween(0, 1).WithMessage("PhanTram must between 0 to 1");

            RuleFor(x => x.LyDo)
                .MaximumLength(200).WithMessage("Maximum length is 200");

        }
    }
}
