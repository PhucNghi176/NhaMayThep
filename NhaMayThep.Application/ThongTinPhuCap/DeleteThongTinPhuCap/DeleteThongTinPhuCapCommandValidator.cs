using FluentValidation;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinPhuCap.CreateThongTinPhuCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.DeleteThongTinPhuCap
{
    public class DeleteThongTinPhuCapCommandValidator : AbstractValidator<DeleteThongTinPhuCapCommand>
    {
        private readonly IThongTinPhuCap _repository;
        public DeleteThongTinPhuCapCommandValidator(IThongTinPhuCap repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinPhuCapById(id, cancellationToken) != null)
                .WithMessage("ID is not null or ID is not found.");
        }
    }
}
