using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdQueryValidator : AbstractValidator<GetThongTinGiamTruByIdQuery>
    {
        public GetThongTinGiamTruByIdQueryValidator()
        {
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("ID is null");
        }
    }
}
