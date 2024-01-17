using FluentValidation;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommandValidator : AbstractValidator<UpdateLichSuCongTacNhanVienCommand>
    {
        public UpdateLichSuCongTacNhanVienCommandValidator()
        {
            RuleFor(command => command.ID).NotEmpty().WithMessage("ID lịch sử công tác nhân viên không được để trống");
            RuleFor(command => command.LoaiCongTacID).GreaterThan(0).WithMessage("ID loại công tác phải là số dương");
            RuleFor(command => command.NgayBatDau).NotEmpty().WithMessage("Ngày bắt đầu không được trống");
            RuleFor(command => command.NgayKetThuc).NotEmpty().WithMessage("Ngày kết thúc không được trống");
            RuleFor(command => command.NoiCongTac).NotEmpty().WithMessage("Nơi công tác không được trống");
            RuleFor(command => command.LyDo).NotEmpty().WithMessage("Lý do không được trống");
            RuleFor(command => command.NgayKetThuc).GreaterThanOrEqualTo(command => command.NgayBatDau)
                .WithMessage("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu");
        }
    }
}
