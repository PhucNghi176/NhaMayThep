using FluentValidation;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommandValidator : AbstractValidator<UpdateLuongSanPhamCommand>
    {
        public UpdateLuongSanPhamCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MaximumLength(450).WithMessage("ID không vượt quá 450 kí tự.");

            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("NhanVienID không được để trống.")
                .MaximumLength(450).WithMessage("NhanVienID không vượt quá 450 kí tự.");

            RuleFor(x => x.SoSanPhamLam)
                .NotNull().WithMessage("SoSanPhamLam không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("SoSanPhamLam phải lớn hoặc bằng 0");

            RuleFor(x => x.MucSanPhamID)
                .NotNull().WithMessage("MucSanPhamID không được để trống.");

            RuleFor(x => x.TongLuong)
                .NotNull().WithMessage("TongLuong không được để trống.")
                .GreaterThanOrEqualTo(0).WithMessage("TongLuong phải lớn 0");

            RuleFor(x => x.NgayKhaiBao)
                .NotEmpty().WithMessage("Ngày khai báo không được để trống")
                .NotNull().WithMessage("Ngày khai báo không hợp lệ");
        }
    }
}