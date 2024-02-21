using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQueryValidator : AbstractValidator<GetThongTinCongDoanByIdQuery>
    {
        public GetThongTinCongDoanByIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
               .NotNull().WithMessage("Mã thông tin công đoàn không được rỗng");
        }
    }
}
