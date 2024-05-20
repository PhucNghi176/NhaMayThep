using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommandValidator : AbstractValidator<DeleteThongTinGiamTruCommand>
    {
        public readonly IThongTinGiamTruRepository _repository;
        public DeleteThongTinGiamTruCommandValidator(IThongTinGiamTruRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinGiamTruById(id, cancellationToken) != null)
                .WithMessage("ID is null or ID is not found");
        }
    }
}
