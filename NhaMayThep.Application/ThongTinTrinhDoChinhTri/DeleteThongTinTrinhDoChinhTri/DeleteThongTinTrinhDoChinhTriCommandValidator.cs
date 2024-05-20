using FluentValidation;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri
{
    public class DeleteThongTinTrinhDoChinhTriCommandValidator : AbstractValidator<DeleteThongTinTrinhDoChinhTriCommand>
    {
        public DeleteThongTinTrinhDoChinhTriCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Mã thông tin trình độ chính trị không được để trống")
                .NotNull().WithMessage("Mã thông tin trình độ chính trị không được rỗng");
        }
    }
}
