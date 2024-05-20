using FluentValidation;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetTrangThaiDangKiCaLamViecById
{
    public class GetTrangThaiDangKiCaLamViecByIdValidator : AbstractValidator<GetTrangThaiDangKiCaLamViecByIdQuery>
    {
        public GetTrangThaiDangKiCaLamViecByIdValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id không được để trống.");
        }
    }
}
