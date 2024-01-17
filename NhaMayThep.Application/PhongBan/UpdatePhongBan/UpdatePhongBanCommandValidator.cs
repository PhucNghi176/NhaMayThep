using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandValidator : AbstractValidator<UpdatePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        public UpdatePhongBanCommandValidator(IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(ExistID).WithMessage("Phong Ban is not exist");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require")
                .Must(AvailableName).WithMessage("This name is already exist");
        }

        private bool AvailableName(string name)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.Name == name).Result;
            return phongBan == null ? true : false;
        }

        private bool ExistID(int id)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == id).Result;
            return phongBan == null ? false : true;
        }
    }
}
