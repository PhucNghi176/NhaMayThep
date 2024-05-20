using FluentValidation;

namespace NhaMayThep.Application.LoaiNghiPhep.Update
{
    public class UpdateLoaiNghiPhepValidator : AbstractValidator<UpdateLoaiNghiPhepCommand>
    {
        public UpdateLoaiNghiPhepValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Name).NotEmpty().WithMessage("Tên không để trống.");

        }
    }
}