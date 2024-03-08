using FluentValidation;
using NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.GetId
{
    public class GetDangKiCaLamByIdQueryValidator : AbstractValidator<GetDangKiCaLamByIdQuery>
    {
        public GetDangKiCaLamByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(query => query.Id).NotEmpty().WithMessage("MaCaLamViec khong de trong");
        }
    }
}
