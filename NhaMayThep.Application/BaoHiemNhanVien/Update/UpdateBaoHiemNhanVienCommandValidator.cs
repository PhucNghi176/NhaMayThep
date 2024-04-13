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
            RuleFor(x => x.BaoHiem).NotEmpty().WithMessage("BaoHiem là bắt buộc");
            RuleFor(x => x.BaoHiem).GreaterThan(0).WithMessage("BaoHiem phải lớn hơn 0");
        }
    }
}
