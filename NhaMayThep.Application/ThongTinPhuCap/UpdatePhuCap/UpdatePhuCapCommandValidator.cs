using FluentValidation;

namespace NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap
{
    public class UpdatePhuCapCommandValidator : AbstractValidator<UpdatePhuCapCommand>
    {
        public UpdatePhuCapCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be null or empty");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ten phu cap must not be null or empty");
            RuleFor(x => x.PhanTramPhuCap).NotNull().NotEmpty().WithMessage("Phan tram phu cap must not be null or empty");
        }
    }
}
