using FluentValidation;

namespace NhaMayThep.Application.HopDong.CreateHopDongWithExcel
{
    public class CreateHopDongWithExcelCommandValidator : AbstractValidator<CreateHopDongWithExcelCommand>
    {
        public CreateHopDongWithExcelCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Files)
                .NotEmpty()
                .NotNull()
                .WithMessage("Xin vui lòng nhập file");
        }
    }
}
