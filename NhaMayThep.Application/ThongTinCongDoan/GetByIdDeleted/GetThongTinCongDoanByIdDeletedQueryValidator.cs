using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByIdDeleted
{
    public class GetThongTinCongDoanByIdDeletedQueryValidator : AbstractValidator<GetThongTinCongDoanByIdDeletedQuery>
    {
        public GetThongTinCongDoanByIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Mã thông tin công đoàn không được để trống")
               .NotNull().WithMessage("Mã thông tin công đoàn không được rỗng");
        }
    }
}
