using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy
{
    public class UpdateThongTinCongTyCommandValidator : AbstractValidator<UpdateThongTinCongTyCommand>
    {
        public UpdateThongTinCongTyCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().WithMessage("Mã doanh nghiệp không được để trống")
                .NotNull().WithMessage("Mã doanh nghiệp không được rỗng");
            RuleFor(x => x.NgayHoatDong)
                .Must(NgayHoatDong => NgayHoatDong == DateTime.MinValue || NgayHoatDong <= DateTime.Now)
                .WithMessage("Ngày hoạt động không thể lớn hơn ngày hiện tại"); ;

        }
    }
}
