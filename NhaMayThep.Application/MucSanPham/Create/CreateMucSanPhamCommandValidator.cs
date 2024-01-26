using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .GreaterThan(0).WithMessage("MucSanPhamToiDa phải lớn hơn 0");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name không được trống");
        }
    }
}
