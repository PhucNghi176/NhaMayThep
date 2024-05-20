using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem
{
    public class DeleteChiTietBaoHiemCommandValidator : AbstractValidator<DeleteChiTietBaoHiemCommand>
    {
        public DeleteChiTietBaoHiemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được bỏ trống");
        }
    }
}
