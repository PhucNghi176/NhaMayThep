using FluentValidation;

namespace NhaMayThep.Application.ThongTinDaoTao.Update
{
    public class UpdateThongTinDaoTaoCommandValidator : AbstractValidator<UpdateThongTinDaoTaoCommand>
    {
        public UpdateThongTinDaoTaoCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            
            RuleFor(x => x.TenTruong).NotEmpty().WithMessage("TenTruong is required");
            RuleFor(x => x.ChuyenNganh).NotEmpty().WithMessage("ChuyenNganh is required");
            RuleFor(x => x.NamTotNghiep).NotEmpty().WithMessage("NamTotNghiep is required");
            RuleFor(x => x.TrinhDoVanHoa).NotEmpty().WithMessage("TrinhDoVanHoa is required");
            RuleFor(x => x.TrinhDoVanHoa).GreaterThanOrEqualTo(0).WithMessage("TrinhDoVanHoa must not be negative");
        }
       
    }
}
