using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucVu.GetChucVuById
{
    public class GetChucVuByIdQueryValidator : AbstractValidator<GetChucVuByIdQuery>
    {
        public GetChucVuByIdQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.ID).NotEmpty().NotNull().WithMessage("Id must not be null or empty");
        }
    }
}
