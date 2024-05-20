using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandValidator : AbstractValidator<CreateTinhTrangLamViecCommand>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        public CreateTinhTrangLamViecCommandValidator(ITinhTrangLamViecRepository repository)
        {
            _repository = repository;
        }
    }
}
