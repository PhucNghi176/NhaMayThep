using FluentValidation;

namespace NhaMayThep.Application.ThueSuat.UpdateThueSuat
{
    public class UpdateThueSuatCommandValidator : AbstractValidator<UpdateThueSuatCommand>
    {
        public UpdateThueSuatCommandValidator()
        {
            RuleFor(x => x.ID)
                .NotEmpty().NotNull()
                .WithMessage("ID không được để trống.");
            RuleFor(x => x.PhanTramThueSuat)
                .GreaterThanOrEqualTo(0).LessThanOrEqualTo(100)
                .WithMessage("Phần trăm thuế suất phải từ 0 đến 100.");
        }
    }
}
