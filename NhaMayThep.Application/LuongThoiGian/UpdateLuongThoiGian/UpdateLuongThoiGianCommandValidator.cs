using FluentValidation;

namespace NhaMayThep.Application.LuongThoiGian.UpdateLuongThoiGian
{
    public class UpdateLuongThoiGianCommandValidator : AbstractValidator<UpdateLuongThoiGianCommand>
    {
        public UpdateLuongThoiGianCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã lương thời gian không được để trống")
                .NotNull().WithMessage("Mã lương thời gian không được rỗng");
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã số nhân viên không được để trống")
                .NotNull().WithMessage("Mã số nhân viên không được rỗng");
            RuleFor(x => x.NgayApDung)
                .Must(ngayApDung => ngayApDung == DateTime.MinValue || ngayApDung <= DateTime.Now)
                .WithMessage("Ngày áp dụng không thể lớn hơn ngày hiện tại"); ;
        }
    }
}
