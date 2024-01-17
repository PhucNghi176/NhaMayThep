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
        private readonly IThongTinGiamTruReposiyory _repository;
        public GetThongTinGiamTruByIdQueryValidator(IThongTinGiamTruReposiyory repository)
        {
            _repository = repository;
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
