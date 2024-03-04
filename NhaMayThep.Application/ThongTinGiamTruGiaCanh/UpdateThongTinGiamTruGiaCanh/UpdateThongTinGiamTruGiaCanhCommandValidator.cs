using FluentValidation;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommandValidator : AbstractValidator<UpdateThongTinGiamTruGiaCanhCommand>
    {
        public UpdateThongTinGiamTruGiaCanhCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Id không được bỏ trống")
              .NotNull().WithMessage("Id không được rỗng");
            RuleFor(x => x.MaGiamTruID)
                 .GreaterThan(0)
                 .WithMessage("Mã giảm trừ phải lớn hơn 0")
                 .LessThan(int.MaxValue).WithMessage($"Mã giảm trừ phải bé hơn {int.MaxValue}");

            RuleFor(x => x.QuanHeVoiNhanVien)
             .MaximumLength(20).WithMessage("Quan hệ với nhân viên có tối đa 20 ký tự");

            RuleFor(x => x.CanCuocCongDan)
             .NotEmpty().WithMessage("Căn cước công dân không được bỏ trống")
             .NotNull().WithMessage("Căn cước công dân không được rỗng")
             .MaximumLength(12).WithMessage("Căn cước công dân có độ dài tối đa 12 ký tự")
             .Must(x => long.TryParse(x, out long _)).WithMessage("Căn cước công dân phải là số");

            RuleFor(x => x.NgayXacNhanPhuThuoc)
                .Must(ngayGiaNhap => ngayGiaNhap == DateTime.MinValue || ngayGiaNhap <= DateTime.Now)
                .WithMessage("Ngày xác nhận phụ thuộc không thể lớn hơn ngày hiện tại");
        }
    }
}
