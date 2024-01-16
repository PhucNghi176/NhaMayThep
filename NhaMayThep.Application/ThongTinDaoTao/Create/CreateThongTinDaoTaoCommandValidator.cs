using FluentValidation;

namespace NhaMayThep.Application.ThongTinDaoTao.Create
{
    public class CreateThongTinDaoTaoCommandValidator : AbstractValidator<CreateThongTinDaoTaoCommand>
    {
        public CreateThongTinDaoTaoCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.NhanVienId).NotEmpty().WithMessage("NhanVienId is required");
            RuleFor(x => x.MaTrinhDoHocVanId).GreaterThan(0).WithMessage("MaTrinhDoHocVanId must be greater than 0");
            RuleFor(x => x.TenTruong).NotEmpty().WithMessage("TenTruong is required");
            RuleFor(x => x.ChuyenNganh).NotEmpty().WithMessage("ChuyenNganh is required");
            RuleFor(x => x.NamTotNghiep).NotEmpty().WithMessage("NamTotNghiep is required");
            RuleFor(x => x.TrinhDoVanHoa).GreaterThan(0).WithMessage("TrinhDoVanHoa must be greater than 0");
        }
    }
}
