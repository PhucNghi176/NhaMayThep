using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQueryValidator : AbstractValidator<GetThongTinCongDoanByIdQuery>
    {
        public GetThongTinCongDoanByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => Guid.TryParseExact(x, "N", out _)).WithMessage("Mã thông tin công đoàn không đúng định dạng");
        }
    }
}
