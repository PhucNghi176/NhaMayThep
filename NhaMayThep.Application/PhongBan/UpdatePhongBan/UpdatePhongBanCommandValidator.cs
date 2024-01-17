using FluentValidation;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommandValidator : AbstractValidator<UpdatePhongBanCommand>
    {
        public UpdatePhongBanCommandValidator(IPhongBanRepository phongBanRepository)
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ID)
                .NotNull().WithMessage("ID is require");
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is require");
        }
    }
}
