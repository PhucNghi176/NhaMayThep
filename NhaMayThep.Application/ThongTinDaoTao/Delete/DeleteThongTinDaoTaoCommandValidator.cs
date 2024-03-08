using FluentValidation;

namespace NhaMayThep.Application.ThongTinDaoTao.Delete
{
    public class DeleteThongTinDaoTaoCommandValidator : AbstractValidator<DeleteThongTinDaoTaoCommand>
    {
        public DeleteThongTinDaoTaoCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID là bắt buộc");
        }
    }
}
