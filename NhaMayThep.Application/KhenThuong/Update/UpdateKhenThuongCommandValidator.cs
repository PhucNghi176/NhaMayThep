using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Update
{
    public class UpdateKhenThuongCommandValidator : AbstractValidator<UpdateKhenThuongCommand>
    {
        public UpdateKhenThuongCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.TongGiaTri)
                .GreaterThan(0).WithMessage("Tong Gia Tri must be greater than 0");
        }
    }
}
