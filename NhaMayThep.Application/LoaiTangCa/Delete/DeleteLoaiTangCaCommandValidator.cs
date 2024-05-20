using FluentValidation;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommandValidator : AbstractValidator<DeleteLoaiTangCaCommand>
    {
        public DeleteLoaiTangCaCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

        }
    }
}
