using FluentValidation;

namespace NhaMayThep.Application.BaoHiem.GetBaoHiemById
{
    public class GetBaoHiemByIdQueryValidator : AbstractValidator<GetBaoHiemByIdQuery>
    {
        public GetBaoHiemByIdQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id must not null or empty");
        }
    }
}
