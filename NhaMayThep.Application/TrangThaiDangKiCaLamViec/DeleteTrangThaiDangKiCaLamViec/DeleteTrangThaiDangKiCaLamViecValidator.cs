using FluentValidation;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec
{
    public class DeleteTrangThaiDangKiCaLamViecValidator : AbstractValidator<DeleteTrangThaiDangKiCaLamViecCommand>
    {
        public DeleteTrangThaiDangKiCaLamViecValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
        }
    }
}
