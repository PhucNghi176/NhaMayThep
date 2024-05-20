using FluentValidation;

namespace NhaMayThep.Application.KhaiBaoTangLuong.GetId
{
    public class GetKhaiBaoTangLuongByIdQueryValidator : AbstractValidator<GetKhaiBaoTangLuongByIdQuery>
    {
        public GetKhaiBaoTangLuongByIdQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
