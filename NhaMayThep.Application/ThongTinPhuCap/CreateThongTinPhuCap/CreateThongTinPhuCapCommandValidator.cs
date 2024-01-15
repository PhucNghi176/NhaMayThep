using FluentValidation;
using FluentValidation.Validators;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateThongTinPhuCap
{
    public class CreateThongTinPhuCapCommandValidator : AbstractValidator<CreateThongTinPhuCapCommand>
    {
        private readonly IThongTinPhuCap _repository;
        public CreateThongTinPhuCapCommandValidator(IThongTinPhuCap repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.id)
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinPhuCapById(id, cancellationToken) == null)
                .WithMessage("trùng ID của thông tin phụ cấp !!!");
        }
    }
}
