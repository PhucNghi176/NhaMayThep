using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class UpdateTrinhDoHocVanCommandValidator : AbstractValidator<UpdateTrinhDoHocVanCommand>
    {
        private readonly ITrinhDoHocVanRepository _repository;

        public UpdateTrinhDoHocVanCommandValidator(ITrinhDoHocVanRepository repository)
        {
            _repository = repository;

            //RuleFor(x => x.Id).GreaterThan(0).Must(BeUnique).WithMessage("Id must be unique");
            RuleFor(x => x.TenTrinhDo).NotEmpty().MaximumLength(255);
        }

        //private bool BeUnique(int id)
        //{
        //    var existingEntity = _repository.FindByIdAsync(id).Result;
        //    return existingEntity == null;
        //}
    }
}
