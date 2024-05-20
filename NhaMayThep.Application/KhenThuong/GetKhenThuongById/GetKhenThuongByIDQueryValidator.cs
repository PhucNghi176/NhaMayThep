using FluentValidation;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQueryValidator : AbstractValidator<GetKhenThuongByIDQuery>
    {
        public GetKhenThuongByIDQueryValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
        }
    }
}
