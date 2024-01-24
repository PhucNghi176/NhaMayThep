using FluentValidation;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.Create
{
    public class CreateHoaDonCongTacNhanVienCommandValidator : AbstractValidator<CreateHoaDonCongTacNhanVienCommand>
    {
        public CreateHoaDonCongTacNhanVienCommandValidator()
        {
            RuleFor(command => command.LichSuCongTacID)
                .NotEmpty().WithMessage("LichSuCongTacID không được để trống.");

            RuleFor(command => command.LoaiHoaDonID)
                .NotEmpty().WithMessage("LoaiHoaDonID không được để trống.");

            RuleFor(command => command.formFile)
                .NotNull().WithMessage("formFile không được để trống.");

            RuleFor(command => command.NameForFile)
                .NotEmpty().WithMessage("NameForFile không được để trống.");
        }
    }
}
