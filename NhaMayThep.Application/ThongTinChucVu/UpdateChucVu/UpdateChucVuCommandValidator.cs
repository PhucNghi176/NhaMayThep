using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucVu.UpdateChucVu
{
    public class UpdateChucVuCommandValidator : AbstractValidator<UpdateChucVuCommand>
    {
        public UpdateChucVuCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be null or empty");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ten chuc vu must not be null or empty");
        }
    }
}
