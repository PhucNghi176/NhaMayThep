using FluentValidation;

namespace NhaMayThep.Application.TangCa.Create
{
    public class CreateTangCaCommandValidator : AbstractValidator<CreateTangCaCommand>
    {
        public CreateTangCaCommandValidator()
        {
            RuleFor(x => x.SoSanPhamLamThem)
                .NotNull().WithMessage("SoSanPhamLamThem không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoSanPhamLamThem phải lớn hoặc bằng 0");
            RuleFor(x => x.SoGioLamThem)
                .NotNull().WithMessage("SoGioLamThem không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoSanPhamLamThem phải lớn hoặc bằng 0");
            RuleFor(x => x.LuongSanPham)
                .NotNull().WithMessage("LuongSanPham không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongSanPham phải lớn hoặc bằng 0");
            RuleFor(x => x.LuongCongNhat)
                .NotNull().WithMessage("LuongCongNhat không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("LuongCongNhat phải lớn hoặc bằng 0");
        }
    }
}
