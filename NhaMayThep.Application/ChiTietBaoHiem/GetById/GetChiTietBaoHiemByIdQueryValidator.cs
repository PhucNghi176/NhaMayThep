using FluentValidation;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetById
{
    public class GetChiTietBaoHiemByIdQueryValidator : AbstractValidator<GetChiTietBaoHiemByIdQuery>
    {
        public GetChiTietBaoHiemByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id không được bỏ trống");
        }
    }
}
