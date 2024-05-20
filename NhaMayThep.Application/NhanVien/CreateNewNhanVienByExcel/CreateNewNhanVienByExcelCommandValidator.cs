using FluentValidation;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienByExcel
{
    public class CreateNewNhanVienByExcelCommandValidator : AbstractValidator<CreateNewNhanVienByExcelCommand>
    {
        public CreateNewNhanVienByExcelCommandValidator()
        {
            Configure();
        }

        public void Configure()
        {
            RuleFor(x => x.InputFiles).NotEmpty()
                .NotNull()
                .WithMessage("Vui lòng không được để trống các files excel");
        }
    }
}
