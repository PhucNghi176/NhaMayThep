using FluentValidation;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Delete
{
    public class DeleteThongTinLuongNhanVienCommandValidator : AbstractValidator<DeleteThongTinLuongNhanVienCommand>
    {
        public DeleteThongTinLuongNhanVienCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
        }
    }
}
