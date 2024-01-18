using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandValidator : AbstractValidator<DeletePhongBanCommand>
    {
        IPhongBanRepository _phongBanRepository;
        public DeletePhongBanCommandValidator(IPhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require")
                .Must(ExistId).WithMessage("ID is not exist");
        }

        private bool ExistId(int id)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == id).Result;
            return phongBan == null ? false : true;
        }
    }
}
