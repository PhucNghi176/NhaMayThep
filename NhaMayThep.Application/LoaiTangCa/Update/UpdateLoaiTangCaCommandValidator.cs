using FluentValidation;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaValidator : AbstractValidator<UpdateLoaiTangCaCommand>
    {
        public UpdateLoaiTangCaValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required.");

        }
    }
}
