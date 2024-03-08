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
            RuleFor(x => x.NhanVienId).NotEmpty().WithMessage("NhanVienId là bắt buộc");
            RuleFor(x => x.MaTrinhDoHocVanId).GreaterThan(0).WithMessage("MaTrinhDoHocVanId phải lớn hơn 0");
            RuleFor(x => x.TenTruong).NotEmpty().WithMessage("TenTruong là bắt buộc");
            RuleFor(x => x.ChuyenNganh).NotEmpty().WithMessage("ChuyenNganh là bắt buộc");
            RuleFor(x => x.NamTotNghiep).NotEmpty().WithMessage("NamTotNghiep là bắt buộc");
            RuleFor(x => x.TrinhDoVanHoa).InclusiveBetween(1, 12).WithMessage("TrinhDoVanHoa phải nằm giữa từ 1 đến 12");
        }
    }
}
