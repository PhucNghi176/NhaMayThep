using FluentValidation;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu
{
    public class GetSingleThongTinQuaTrinhNhanSuQueryValidator : AbstractValidator<GetSingleThongTinQuaTrinhNhanSuQuery>
    {
        public GetSingleThongTinQuaTrinhNhanSuQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID is require");
        }
    }
}
