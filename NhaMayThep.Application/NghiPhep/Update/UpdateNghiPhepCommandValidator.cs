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
            RuleFor(x => x.LuongNghiPhep).NotEmpty().WithMessage("LuongNghiPhep is required");
            RuleFor(x => x.LuongNghiPhep).GreaterThanOrEqualTo(0).WithMessage("LuongNghiPhep must not be negative");

            RuleFor(x => x.KhoanTruLuong).NotEmpty().WithMessage("KhoanTruLuong is required");
            RuleFor(x => x.KhoanTruLuong).GreaterThanOrEqualTo(0).WithMessage("KhoanTruLuong must not be negative");

            RuleFor(x => x.SoGioNghiPhep).NotEmpty().WithMessage("SoGioNghiPhep is required");
            RuleFor(x => x.SoGioNghiPhep).GreaterThanOrEqualTo(0).WithMessage("SoGioNghiPhep must not be negative");

            RuleFor(x => x.LoaiNghiPhepId).NotEmpty().WithMessage("LoaiNghiPhepId is required");
            RuleFor(x => x.LoaiNghiPhepId).GreaterThan(0).WithMessage("LoaiNghiPhepId must be greater than 0");
        }
    }
}
