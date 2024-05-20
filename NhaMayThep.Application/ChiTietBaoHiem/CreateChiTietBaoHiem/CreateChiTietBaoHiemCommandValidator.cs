using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem
{
    public class CreateChiTietBaoHiemCommandValidator : AbstractValidator<CreateChiTietBaoHiemCommand>
    {
        public CreateChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.NgayHieuLuc)
                .Must(x => x == DateTime.MinValue || x <= DateTime.Now)
                .WithMessage("Ngày hiệu lực không thể lớn hơn ngày hiện tại");
            RuleFor(x => x.NgayKetThuc)
                .Must(x => x == DateTime.MaxValue || x > DateTime.Now)
                .WithMessage("Ngày kết thúc không thể bé hơn ngày hiện tại");
        }
    }
}
