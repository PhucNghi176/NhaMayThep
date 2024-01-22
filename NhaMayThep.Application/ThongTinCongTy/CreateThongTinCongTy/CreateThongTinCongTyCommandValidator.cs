using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommandValidator : AbstractValidator<CreateThongTinCongTyCommand>
    {
        public CreateThongTinCongTyCommandValidator()
        {
            ConfigureValidationRules();
        }
        private void ConfigureValidationRules()
        {    
            RuleFor(t => t.TenQuocTe).NotEmpty().NotNull().WithMessage("Ten quoc te must not be null or empty.");
            RuleFor(t => t.TenVietTat).NotEmpty().NotNull().WithMessage("Ten viet tat must not be null or empty.");
            RuleFor(t => t.SoLuongNhanVien).NotEmpty().NotNull().WithMessage("So luong nhan vien must not be null or empty.");
            RuleFor(t => t.DiaChi).NotEmpty().NotNull().WithMessage("Dia chi must not be null or empty.");
            RuleFor(t => t.MaSoThue).NotEmpty().NotNull().WithMessage("Ma so thue must not be null or empty.");
            RuleFor(t => t.DienThoai).NotEmpty().NotNull().WithMessage("Dien thoai must not be null or empty.");
            RuleFor(t => t.NguoiDaiDien).NotEmpty().NotNull().WithMessage("Nguoi dai dien must not be null or empty.");
            RuleFor(t => t.NgayHoatDong).NotEmpty().NotNull().WithMessage("Ngay hoat dong must not be null or empty.");
            RuleFor(t => t.DonViQuanLi).NotEmpty().NotNull().WithMessage("Don vi quan li not be null or empty.");
            RuleFor(t => t.LoaiHinhDoanhNghiep).NotEmpty().NotNull().WithMessage("Loai hinh doanh nghiep must not be null or empty.");
            RuleFor(t => t.TinhTrang).NotEmpty().NotNull().WithMessage("Tinh trang must not be null or empty.");
        }
    }
}