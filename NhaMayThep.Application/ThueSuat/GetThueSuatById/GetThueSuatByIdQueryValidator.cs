using FluentValidation;

namespace NhaMayThep.Application.ThueSuat.GetThueSuatById
{
    public class GetThueSuatByIdQueryValidator : AbstractValidator<GetThueSuatByIdQuery>
    {
        public GetThueSuatByIdQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
