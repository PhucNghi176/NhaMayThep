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
            
            RuleFor(x => x.TenTruong).NotEmpty().WithMessage("TenTruong là bắt buộc");
            RuleFor(x => x.ChuyenNganh).NotEmpty().WithMessage("ChuyenNganh là bắt buộc");
            RuleFor(x => x.NamTotNghiep).NotEmpty().WithMessage("NamTotNghiep là bắt buộc");
            RuleFor(x => x.TrinhDoVanHoa).NotEmpty().WithMessage("TrinhDoVanHoa là bắt buộc");
            RuleFor(x => x.TrinhDoVanHoa).GreaterThanOrEqualTo(0).WithMessage("TrinhDoVanHoa phải lớn hơn 0");
        }
       
    }
}
