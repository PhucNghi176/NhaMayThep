using FluentValidation;

namespace NhaMayThep.Application.KyLuat.CreateKyLuat
{
    public class CreateKyLuatCommandValidator : AbstractValidator<CreateKyLuatCommand>
    {
        public CreateKyLuatCommandValidator()
        {
            ConfigureValidasionRules();
        }
        public void ConfigureValidasionRules()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().NotNull()
                .WithMessage("Mã số nhân sự không được để trống.");
            RuleFor(x => x.ChinhSachNhanSuID)
                .NotEmpty().NotNull()
                .WithMessage("Chính sách nhân sự không được để trống.");
            RuleFor(x => x.TenDotKyLuat)
                .NotNull().NotEmpty()
                .WithMessage("Tên đợt kỷ luật không được để trống.");
        }
    }
}
