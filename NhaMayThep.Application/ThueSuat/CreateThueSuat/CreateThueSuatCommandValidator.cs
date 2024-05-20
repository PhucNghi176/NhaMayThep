using FluentValidation;

namespace NhaMayThep.Application.ThueSuat.CreateThueSuat
{
    public class CreateThueSuatCommandValidator : AbstractValidator<CreateThueSuatCommand>
    {
        public CreateThueSuatCommandValidator()
        {
            RuleFor(x => x.BacThue)
                .NotEmpty().NotNull()
                .WithMessage("Bậc thuế không được để trống");
            RuleFor(x => x.DauThuNhapTinhThueTrenThang)
                .NotEmpty().NotNull()
                .WithMessage("Đầu Thu nhập tính thuế trên tháng không được để trống");
            RuleFor(x => x.CuoiThuNhapTinhThueTrenThang)
                .NotEmpty().NotNull()
                .WithMessage("Cuối Thu nhập tính thuế trên tháng không được để trống");
            RuleFor(x => x.DauThuNhapTinhThueTrenNam)
                .NotEmpty().NotNull()
                .WithMessage("Đầu Thu nhập tính thuế trên năm không được để trống");
            RuleFor(x => x.CuoiThuNhapTinhThueTrenNam)
                .NotEmpty().NotNull()
                .WithMessage("Cuối Thu nhập tính thuế trên năm không được để trống");
            RuleFor(x => x.PhanTramThueSuat)
                .NotEmpty().NotNull()
                .WithMessage("Phần trăm thuế suất không được để trống");
            RuleFor(x => x.PhanTramThueSuat)
                .GreaterThanOrEqualTo(0).LessThanOrEqualTo(100)
                .WithMessage("Phần trăm thuế suất phải từ 0 đến 100.");
        }
    }
}
