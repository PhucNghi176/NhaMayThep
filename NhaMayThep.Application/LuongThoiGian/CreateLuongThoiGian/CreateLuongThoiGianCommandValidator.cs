using FluentValidation;

namespace NhaMayThep.Application.LuongThoiGian.CreateLuongThoiGian
{
    public class CreateLuongThoiGianCommandValidator : AbstractValidator<CreateLuongThoiGianCommand>
    {
        public CreateLuongThoiGianCommandValidator()
        {
            RuleFor(x => x.MaSoNhanVien)
                .NotEmpty().WithMessage("Mã số nhân viên không được để trống.");

            RuleFor(x => x.MaLuongThoiGian)
                .NotEmpty().WithMessage("Mã lương thời gian không được để trống.");

            RuleFor(x => x.NgayApDung)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Ngày áp dụng không được lớn hơn ngày hiện tại.");
        }
    }
}
