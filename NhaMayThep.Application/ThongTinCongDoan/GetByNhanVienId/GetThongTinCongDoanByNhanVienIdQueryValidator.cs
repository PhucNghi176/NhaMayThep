using FluentValidation;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId
{
    public class GetThongTinCongDoanByNhanVienIdQueryValidator : AbstractValidator<GetThongTinCongDoanByNhanVienIdQuery>
    {
        public GetThongTinCongDoanByNhanVienIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Mã nhân viên không được để trống")
               .NotNull().WithMessage("Mã nhân viên không được rỗng");
        }
    }
}
