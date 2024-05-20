using FluentValidation;

namespace NhaMayThep.Application.BaoHiem.UpdateBaoHiem
{
    public class UpdateBaoHiemCommandValidator : AbstractValidator<UpdateBaoHiemCommand>
    {
        public UpdateBaoHiemCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.Id).NotEmpty()
                .NotNull()
                .WithMessage("Id must not null or empty");
            RuleFor(x => x.TenLoaiBaoHiem).NotEmpty()
               .NotNull()
               .WithMessage("Ten loai bao hiem must not null or empty");
            RuleFor(x => x.PhanTramKhauTru).NotEmpty()
               .NotNull()
               .WithMessage("Phan tram khau tru must not null or empty");
        }
    }
}
