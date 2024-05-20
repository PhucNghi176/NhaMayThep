using FluentValidation;

namespace NhaMayThep.Application.TrinhDoHocVan.Create
{
    public class CreateTrinhDoHocVanCommandValidator : AbstractValidator<CreateTrinhDoHocVanCommand>
    {
        public CreateTrinhDoHocVanCommandValidator()
        {
            RuleFor(x => x.TenTrinhDo).NotEmpty().MaximumLength(255);
        }
    }
}
