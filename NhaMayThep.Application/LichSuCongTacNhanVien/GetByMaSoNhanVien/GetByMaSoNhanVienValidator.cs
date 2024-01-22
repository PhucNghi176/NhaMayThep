using FluentValidation;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien
{
    public class GetByMaSoNhanVienValidator : AbstractValidator<GetByMaSoNhanVienQuery>
    {
        public GetByMaSoNhanVienValidator()
        {
            RuleFor(command => command.MaSoNhanVien).NotEmpty().WithMessage("Mã số nhân viên không được trống");
        }
    }
}
