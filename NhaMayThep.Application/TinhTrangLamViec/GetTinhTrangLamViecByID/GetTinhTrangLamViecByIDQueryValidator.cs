using FluentValidation;

namespace NhaMayThep.Application.TinhTrangLamViec.GetTinhTrangLamViecByID
{
    public class GetTinhTrangLamViecByIDQueryValidator : AbstractValidator<GetTinhTrangLamViecByIDQuery>
    {
        public GetTinhTrangLamViecByIDQueryValidator()
        {
            RuleFor(x => x.id)
                .NotNull().WithMessage("Id không được để trống.");
        }
    }
}
