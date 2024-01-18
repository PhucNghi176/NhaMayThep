using FluentValidation;

namespace NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap
{
    public class GetAllPhuCapQueryValidator : AbstractValidator<GetAllPhuCapQuery>
    {
        public GetAllPhuCapQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
