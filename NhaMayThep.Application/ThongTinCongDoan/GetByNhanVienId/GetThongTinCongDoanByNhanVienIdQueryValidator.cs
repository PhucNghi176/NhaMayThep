using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQueryValidator : AbstractValidator<GetThongTinCongDoanByNhanVienIdQuery>
    {
        public GetThongTinCongDoanByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã nhân viên không đúng định dạng");
        }
    }
}
