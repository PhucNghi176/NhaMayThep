using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandValidator : AbstractValidator<CreateThongTinCongDoanCommand>
    {
        public CreateThongTinCongDoanCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống")
                .NotNull().WithMessage("Mã nhân viên không được rỗng")
                .Must(x => Guid.TryParseExact(x,"N",out _)).WithMessage("Mã nhân viên không đúng định dạng");
            RuleFor(x => x.ThuKyCongDoan)
                .Must(x => x == true || x == false)
                .WithMessage("Sai định dạng dữ liệu thư ký công đoàn");
            RuleFor(x => x.NgayGiaNhap)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("Ngày gia nhập không thể lớn hơn ngày hiện tại"); ;
        }
    }
}
