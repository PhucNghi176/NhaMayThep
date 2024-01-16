using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.GetAll
{
    public class GetAllChinhSachNhanSuQueryValidator : AbstractValidator<GetAllChinhSachNhanSuQuery>
    {
        public GetAllChinhSachNhanSuQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
