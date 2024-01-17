using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandValidator : AbstractValidator<CreateTinhTrangLamViecCommand>
    {
        public readonly ITinhTrangLamViecRepository _repository;
        public CreateTinhTrangLamViecCommandValidator( ITinhTrangLamViecRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public async void ConfigureValidationRules()
        {
        }
    }
}
