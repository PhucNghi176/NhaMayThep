using FluentValidation;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepValidator : AbstractValidator<DeleteLoaiNghiPhepCommand>
    {
        public DeleteLoaiNghiPhepValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

        }
    }
}