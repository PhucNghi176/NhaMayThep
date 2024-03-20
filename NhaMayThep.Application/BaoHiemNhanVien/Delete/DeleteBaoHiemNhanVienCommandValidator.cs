using FluentValidation;


namespace NhaMayThep.Application.BaoHiemNhanVien.Delete
{
    public class DeleteBaoHiemNhanVienCommandValidator : AbstractValidator<DeleteBaoHiemNhanVienCommand>
    {
        public DeleteBaoHiemNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID là bắt buộc");
        }
    }
}
