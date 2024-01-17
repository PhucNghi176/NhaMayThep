using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommandValidator : AbstractValidator<CreateThongTinGiamTruGiaCanhCommand>
    {
        public CreateThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.NhanVienID)
               .NotEmpty().WithMessage("Mã nhân viên không được bỏ trống")
               .NotNull().WithMessage("Mã nhân viên không được rỗng")
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên sai định dạng");

            RuleFor(x => x.MaGiamTruID)
                 .GreaterThan(0)
                 .WithMessage("Mã giảm trừ phải lớn hơn 0")
                 .LessThan(int.MaxValue).WithMessage($"Mã giảm trừ phải bé hơn {int.MaxValue}");


            RuleFor(x => x.DiaChiLienLac)
              .NotEmpty().WithMessage("Mã nhân viên không được rỗng")
              .NotNull().WithMessage("Mã nhân viên không được bỏ trống");

            RuleFor(x => x.QuanHeVoiNhanVien)
             .NotEmpty().WithMessage("Quan hệ với nhân viên không được bỏ trống")
             .NotNull().WithMessage("Quan hệ với nhân viên không được rộng")
             .MaximumLength(20).WithMessage("Quan hệ với nhân viên chứa tối đa 20 ký tự");

            RuleFor(x => x.CanCuocCongDan)
<<<<<<< HEAD
             .NotEmpty().WithMessage("Căn cước công dân không được bỏ trống")
             .NotNull().WithMessage("Căn cước công dân không được bỏ rỗng")
             .MaximumLength(12).WithMessage("Căn cước công dân tối đa 20 ký tự")
             .Must(x=> long.TryParse(x, out long _)).WithMessage("Căn cước công dân phải là số");
=======
             .NotEmpty().WithMessage("CanCuocCongDan must not be empty")
             .NotNull().WithMessage("CanCuocCongDan must not be null")
             .MaximumLength(12).WithMessage("Maximun length is 12")
             .Must(x => long.TryParse(x, out long _)).WithMessage("CanCuocCongDan must an digit");
>>>>>>> origin/main

            RuleFor(x => x.NgayXacNhanPhuThuoc)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("Ngày xác nhận phụ thuộc không thể lớn hơn ngày hiện tại");

        }
    }
}
