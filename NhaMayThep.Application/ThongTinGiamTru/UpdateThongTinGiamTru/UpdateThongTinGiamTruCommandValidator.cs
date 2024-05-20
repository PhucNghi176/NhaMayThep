using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommandValidator : AbstractValidator<UpdateThongTinGiamTruCommand>
    {
        private readonly IThongTinGiamTruRepository _repository;
        public UpdateThongTinGiamTruCommandValidator(IThongTinGiamTruRepository repository)
        {
            _repository = repository;
            ConfigureValidationRules();
        }
        public void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull()
                .MustAsync(async (id, cancellationToken) => await _repository.GetThongTinGiamTruById(id, cancellationToken) != null)
                .WithMessage("ID is null or not found.");
        }

    }
}
