using FluentValidation;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri
{
    public class UpdateThongTinTrinhDoChinhTriCommandValidator : AbstractValidator<UpdateThongTinTrinhDoChinhTriCommand>
    {
        public UpdateThongTinTrinhDoChinhTriCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin trình độ chính trị không được để trống")
                .NotNull().WithMessage("Mã thông tin trình độ chính trị không được rỗng");
            RuleFor(x => x.TenTrinhDoChinhTri)
                .NotEmpty().WithMessage("Tên trình độ chính trị không được để trống")
                .NotNull().WithMessage("Tên trình độ chính trị không được rỗng");
        }
    }
}
