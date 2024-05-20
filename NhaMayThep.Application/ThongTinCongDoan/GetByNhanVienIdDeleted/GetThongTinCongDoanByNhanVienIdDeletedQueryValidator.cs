using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienIdDeleted
{
    public class GetThongTinCongDoanByNhanVienIdDeletedQueryValidator : AbstractValidator<GetThongTinCongDoanByNhanVienIdDeletedQuery>
    {
        public GetThongTinCongDoanByNhanVienIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống")
                .NotNull().WithMessage("Mã nhân viên không được rỗng");
        }
    }
}
