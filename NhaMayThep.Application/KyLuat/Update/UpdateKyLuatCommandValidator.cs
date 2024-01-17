using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Update
{
    public class UpdateKyLuatCommandValidator : AbstractValidator<UpdateKyLuatCommand>
    {
        public UpdateKyLuatCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.TongPhat)
                .GreaterThan(0).WithMessage("Tong Phat must be greater than 0");
        }
    }
}
