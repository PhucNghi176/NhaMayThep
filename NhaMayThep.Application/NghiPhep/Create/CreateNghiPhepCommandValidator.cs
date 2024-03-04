using FluentValidation;

namespace NhaMayThep.Application.NghiPhep.Create
{
    public class CreateNghiPhepCommandValidator : AbstractValidator<CreateNghiPhepCommand>
    {
        public CreateNghiPhepCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.MaSoNhanVien).NotEmpty().WithMessage("MaSoNhanVien is required");
            RuleFor(x => x.LuongNghiPhep).GreaterThan(0).WithMessage("LuongNghiPhep must be greater than 0");
            RuleFor(x => x.KhoanTruLuong).GreaterThan(0).WithMessage("KhoanTruLuong must be greater than 0");
            RuleFor(x => x.SoGioNghiPhep).GreaterThan(0).WithMessage("SoGioNghiPhep must be greater than 0");
            RuleFor(x => x.LoaiNghiPhepId).GreaterThan(0).WithMessage("LoaiNghiPhepId must be greater than 0");
        }
    }
}
