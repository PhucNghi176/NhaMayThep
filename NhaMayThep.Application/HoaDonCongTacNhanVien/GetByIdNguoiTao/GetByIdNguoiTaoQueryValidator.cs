using FluentValidation;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdNguoiTao
{
    public class GetByIdNguoiTaoQueryValidator : AbstractValidator<GetByIdNguoiTaoQuery>
    {
        public GetByIdNguoiTaoQueryValidator()
        {
            RuleFor(command => command.idNguoiTao)
               .NotEmpty().WithMessage("idNguoiTao không được để trống.");
        }
    }
}
