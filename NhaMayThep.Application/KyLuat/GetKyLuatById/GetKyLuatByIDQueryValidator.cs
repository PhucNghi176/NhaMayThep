using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetKyLuatById
{
    public class GetKyLuatByIDQueryValidator : AbstractValidator<GetKyLuatByIDQuery>
    {
        public GetKyLuatByIDQueryValidator()
        {
            ConfigureValidasionRules();
        }
        public void ConfigureValidasionRules()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty()
                .WithMessage("ID không được để trống.");
        }
    }
}
