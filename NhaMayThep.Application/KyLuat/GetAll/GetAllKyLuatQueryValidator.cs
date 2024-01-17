using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetAll
{
    public class GetAllKyLuatQueryValidator : AbstractValidator<GetAllKyLuatQuery>
    {
        public GetAllKyLuatQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
