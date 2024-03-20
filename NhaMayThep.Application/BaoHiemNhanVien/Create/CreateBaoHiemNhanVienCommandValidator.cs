using FluentValidation;

namespace NhaMayThep.Application.BaoHiemNhanVien.Create
{
    public class CreateBaoHiemNhanVienCommandValidator : AbstractValidator<CreateBaoHiemNhanVienCommand>
    {
        public CreateBaoHiemNhanVienCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien).NotEmpty().WithMessage("Mã số nhân viên là bắt buộc");
            RuleFor(x => x.BaoHiem).GreaterThan(0).WithMessage("Mã bảo hiểm phải lớn hơn 0");
        }
    }
}
