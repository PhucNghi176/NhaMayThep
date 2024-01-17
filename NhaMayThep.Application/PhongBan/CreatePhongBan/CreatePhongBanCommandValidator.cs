using FluentValidation;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandValidator : AbstractValidator<CreatePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        public CreatePhongBanCommandValidator(IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(AvailableID).WithMessage("ID is already exist");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require")
                //.MinimumLength(5).WithMessage("Name must be at least 5 character")
                .Must(AvailableName).WithMessage("Phong ban is already exist");              
        }

        private bool AvailableID(int id)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == id).Result;
            return phongBan == null ? true : false;
        }

        private bool AvailableName(string name)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.Name.Equals(name)).Result;
            return phongBan == null ? true : false;
        }
    }
}
