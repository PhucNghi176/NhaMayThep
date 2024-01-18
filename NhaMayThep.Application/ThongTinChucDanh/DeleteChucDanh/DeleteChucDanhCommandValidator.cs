using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucDanh.DeleteChucDanh
{
    public class DeleteChucDanhCommandValidator : AbstractValidator<DeleteChucDanhCommand>
    {
        public DeleteChucDanhCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id must not be empty or null");
        }
    }
}
