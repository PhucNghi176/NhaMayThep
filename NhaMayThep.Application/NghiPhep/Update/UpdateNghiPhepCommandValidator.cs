using FluentValidation;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommandValidator : AbstractValidator<UpdateNghiPhepCommand>
    {
        public UpdateNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.LuongNghiPhep).NotEmpty().WithMessage("LuongNghiPhep là bắt buộc");
            RuleFor(x => x.LuongNghiPhep).GreaterThanOrEqualTo(0).WithMessage("LuongNghiPhep phải là số dương");

            RuleFor(x => x.KhoanTruLuong).NotEmpty().WithMessage("KhoanTruLuong là bắt buộc");
            RuleFor(x => x.KhoanTruLuong).GreaterThanOrEqualTo(0).WithMessage("KhoanTruLuong phải là số dương");

            RuleFor(x => x.SoGioNghiPhep).NotEmpty().WithMessage("SoGioNghiPhep là bắt buộc");
            RuleFor(x => x.SoGioNghiPhep).GreaterThanOrEqualTo(0).WithMessage("SoGioNghiPhep phải là số dương");

            RuleFor(x => x.LoaiNghiPhepId).NotEmpty().WithMessage("LoaiNghiPhepId là bắt buộc");
            RuleFor(x => x.LoaiNghiPhepId).GreaterThan(0).WithMessage("LoaiNghiPhepId phải lớn hơn 0");
        }
    }
}
