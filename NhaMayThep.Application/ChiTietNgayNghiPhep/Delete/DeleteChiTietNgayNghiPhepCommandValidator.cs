using FluentValidation;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public
class DeleteChiTietNgayNghiPhepCommandValidator : AbstractValidator<DeleteChiTietNgayNghiPhepCommand>
    {
        public DeleteChiTietNgayNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("ID không để trống.");

          
        }
    }
}