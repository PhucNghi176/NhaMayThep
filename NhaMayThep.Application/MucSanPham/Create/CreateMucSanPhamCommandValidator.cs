using FluentValidation;

namespace NhaMayThep.Application.MucSanPham.Create
{
    public class CreateMucSanPhamCommandValidator : AbstractValidator<CreateMucSanPhamCommand>
    {
        public CreateMucSanPhamCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.LuongMucSanPham)
                .NotNull().WithMessage("LuongMucSanPham không được trống")
                .GreaterThan(0).WithMessage("LuongMucSanPham phải lớn hơn 0");

            RuleFor(v => v.MucSanPhamToiThieu)
                .NotNull().WithMessage("MucSanPhamToiThieu không được trống")
                .GreaterThanOrEqualTo(0).WithMessage("MucSanPhamToiThieu phải lớn hơn hoặc bằng 0");

            RuleFor(v => v.MucSanPhamToiDa)
                .NotNull().WithMessage("MucSanPhamToiDa không được trống")
                .GreaterThan(x => x.MucSanPhamToiThieu).WithMessage("MucSanPhamToiDa phải lớn hơn MucSanPhamToiThieu");
        }
    }
}
