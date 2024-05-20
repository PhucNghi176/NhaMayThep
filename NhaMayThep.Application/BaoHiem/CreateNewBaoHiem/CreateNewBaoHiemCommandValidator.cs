using FluentValidation;

namespace NhaMayThep.Application.BaoHiem.CreateNewBaoHiem
{
    public class CreateNewBaoHiemCommandValidator : AbstractValidator<CreateNewBaoHiemCommand>
    {
        public CreateNewBaoHiemCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.TenLoaiBaoHiem).NotEmpty()
                .NotNull()
                .WithMessage("Ten loai bao hiem must not null or empty");
            RuleFor(x => x.PhantramKhauTru).NotEmpty()
                .NotNull()
                .WithMessage("Phan tram khau tru must not null or empty");
        }
    }
}
