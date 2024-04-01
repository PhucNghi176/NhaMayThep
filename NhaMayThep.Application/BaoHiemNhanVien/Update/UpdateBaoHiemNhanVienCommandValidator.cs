using FluentValidation;

namespace NhaMayThep.Application.BaoHiemNhanVien.Update
{
    public class UpdateBaoHiemNhanVienCommandValidator : AbstractValidator<UpdateBaoHiemNhanVienCommand>
    {
        public UpdateBaoHiemNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien).NotEmpty().WithMessage("MaSoNhanVien là bắt buộc");
        }
    }
}
