using FluentValidation;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLichSuNghiPhepValidator : AbstractValidator<DeleteLichSuNghiPhepCommand>

    {

        public DeleteLichSuNghiPhepValidator()
        {
            ConfigureValidationRules();
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id không được để trống ");


        }
    }
}
