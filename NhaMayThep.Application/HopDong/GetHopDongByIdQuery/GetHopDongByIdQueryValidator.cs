using FluentValidation;

namespace NhaMayThep.Application.HopDong.GetHopDongByIdQuery
{
    public class GetHopDongByIdQueryValidator : AbstractValidator<GetHopDongByIdQuery>
    {
        public GetHopDongByIdQueryValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not null");
        }
    }
}
