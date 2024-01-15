using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetAll
{
    public class GetAllKhaiBaoTangLuongQueryValidator : AbstractValidator<GetAllKhaiBaoTangLuongQuery>
    {
        public GetAllKhaiBaoTangLuongQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
