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
            RuleFor(x => x.MaSoNhanVien).NotEmpty().WithMessage("MaSoNhanVien là bắt buộc");
            RuleFor(x => x.LuongNghiPhep).GreaterThan(0).WithMessage("LuongNghiPhep phải lớn hơn 0");
            RuleFor(x => x.KhoanTruLuong).GreaterThan(0).WithMessage("KhoanTruLuong phải lớn hơn 0");
            RuleFor(x => x.SoGioNghiPhep).GreaterThan(0).WithMessage("SoGioNghiPhep phải lớn hơn 0");
            RuleFor(x => x.LoaiNghiPhepId).GreaterThan(0).WithMessage("LoaiNghiPhepId phải lớn hơn 0");
        }
    }
}
