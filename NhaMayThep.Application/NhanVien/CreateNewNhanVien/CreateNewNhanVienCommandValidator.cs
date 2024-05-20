using FluentValidation;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVien
{
    public class CreateNewNhanVienCommandValidator : AbstractValidator<CreateNewNhanVienCommand>
    {
        public CreateNewNhanVienCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            // RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.HoVaTen).NotEmpty();
            RuleFor(x => x.ChucVuID).NotEmpty();
            RuleFor(x => x.TinhTrangLamViecID).NotEmpty();
            RuleFor(x => x.NgayVaoCongTy).NotEmpty();
            RuleFor(x => x.DiaChiLienLac).NotEmpty();
            RuleFor(x => x.SoDienThoaiLienLac).NotEmpty();
            RuleFor(x => x.MaSoThue).NotEmpty();
            RuleFor(x => x.TenNganHang).NotEmpty();
            RuleFor(x => x.SoTaiKhoan).NotEmpty();

        }
    }
}
