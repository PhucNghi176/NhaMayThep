using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetById
{
    public class GetChinhSachNhanSuByIdQueryValidator : AbstractValidator<GetChinhSachNhanSuByIdQuery>
    {
        public GetChinhSachNhanSuByIdQueryValidator()
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
