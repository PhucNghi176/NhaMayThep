using FluentValidation;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommandValidator : AbstractValidator<DeleteDangKiCaLamCommand>
    {
        public DeleteDangKiCaLamCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("Id không được để trống ");
        }
    }
}
