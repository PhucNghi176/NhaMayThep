using FluentValidation;

namespace NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById
{
    public class GetPhuCapByIdQueryValidator : AbstractValidator<GetPhuCapByIdQuery>
    {
        public GetPhuCapByIdQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.ID).NotEmpty().NotNull().WithMessage("Id must not be null or empty");
        }
    }
}
