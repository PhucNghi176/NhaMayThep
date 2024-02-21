using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommandValidator : AbstractValidator<CreateThongTinCongTyCommand>
    {
        public CreateThongTinCongTyCommandValidator()
        {
            RuleFor(x => x.MaDoanhNghiep)
                .NotEmpty().WithMessage("Mã doanh nghiệp không được để trống")
                .NotNull().WithMessage("Mã doanh nghiệp không được rỗng");
            RuleFor(x => x.NgayHoatDong)
                .Must(ngayHoatDong => ngayHoatDong == DateTime.MinValue || ngayHoatDong <= DateTime.Now)
                .WithMessage("Ngày hoạt động không thể lớn hơn ngày hiện tại"); ;
        }
    }
}
