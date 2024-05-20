using FluentValidation;

namespace NhaMayThep.Application.TangCa.GetId
{
    public class GetTangCaByIdQueryValidator : AbstractValidator<GetTangCaByIdQuery>
    {
        public GetTangCaByIdQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
