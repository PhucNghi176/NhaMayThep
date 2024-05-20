using FluentValidation;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommandValidator : AbstractValidator<DeleteNhanVienCommand>
    {
        public DeleteNhanVienCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id nhân viên không được null");
        }
    }
}
