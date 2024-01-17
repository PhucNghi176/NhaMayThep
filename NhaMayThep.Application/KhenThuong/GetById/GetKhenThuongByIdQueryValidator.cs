using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetById
{
    public class GetKhenThuongByIdQueryValidator : AbstractValidator<GetKhenThuongByIdQuery>
    {
        public GetKhenThuongByIdQueryValidator()
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
