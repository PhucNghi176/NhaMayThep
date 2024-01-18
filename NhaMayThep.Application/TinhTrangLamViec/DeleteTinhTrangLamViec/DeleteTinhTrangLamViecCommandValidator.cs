using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommandValidator : AbstractValidator<DeleteTinhTrangLamViecCommand>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        public DeleteTinhTrangLamViecCommandValidator(ITinhTrangLamViecRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id is not null");
        }
    }
}
