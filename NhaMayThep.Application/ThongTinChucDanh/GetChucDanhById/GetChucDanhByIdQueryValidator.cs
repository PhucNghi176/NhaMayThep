using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById
{
    public class GetChucDanhByIdQueryValidator : AbstractValidator<GetChucDanhByIdQuery>
    {
        public GetChucDanhByIdQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.ID).NotEmpty().NotNull().WithMessage("Id must not be null or empty");
        }
    }
}
