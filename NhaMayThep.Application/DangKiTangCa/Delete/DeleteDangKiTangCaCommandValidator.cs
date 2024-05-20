using FluentValidation;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaCommandValidator : AbstractValidator<DeleteDangKiTangCaCommand>
    {
        public DeleteDangKiTangCaCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id không được để trống ");
        }
    }
}
