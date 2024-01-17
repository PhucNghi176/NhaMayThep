using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh
{
    public class CreateNewChucDanhValidator : AbstractValidator<CreateNewChucDanhCommand>
    {
        public CreateNewChucDanhValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.TenChucDanh).NotEmpty().NotNull().WithMessage("Ten chuc danh must not be null or empty");
        }
    }
}
