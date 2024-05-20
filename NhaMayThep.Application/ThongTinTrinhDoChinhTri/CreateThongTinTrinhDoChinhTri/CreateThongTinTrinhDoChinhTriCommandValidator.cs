using FluentValidation;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri
{
    public class CreateThongTinTrinhDoChinhTriCommandValidator : AbstractValidator<CreateThongTinTrinhDoChinhTriCommand>
    {
        public CreateThongTinTrinhDoChinhTriCommandValidator()
        {
            RuleFor(x => x.TenTrinhDoChinhTri)
                .NotEmpty().WithMessage("Tên trình độ chính trị không được để trống.")
                .NotNull().WithMessage("Tên trình độ chính trị không được để rỗng.");
        }
    }
}
