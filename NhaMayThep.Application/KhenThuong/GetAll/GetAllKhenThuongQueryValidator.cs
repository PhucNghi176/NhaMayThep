using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetAll
{
    public class GetAllKhenThuongQueryValidator : AbstractValidator<GetAllKhenThuongQuery>
    {
        public GetAllKhenThuongQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
