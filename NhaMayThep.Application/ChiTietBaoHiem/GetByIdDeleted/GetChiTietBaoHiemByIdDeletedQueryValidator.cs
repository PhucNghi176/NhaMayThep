using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetByIdDeleted
{
    public class GetChiTietBaoHiemByIdDeletedQueryValidator : AbstractValidator<GetChiTietBaoHiemByIdDeletedQuery>
    {
        public GetChiTietBaoHiemByIdDeletedQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được bỏ trống");
        }
    }
}
