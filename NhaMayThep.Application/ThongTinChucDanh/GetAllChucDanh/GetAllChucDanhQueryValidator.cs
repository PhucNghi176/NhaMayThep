using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh
{
    public class GetAllChucDanhQueryValidator : AbstractValidator<GetAllChucDanhQuery>
    {
        public GetAllChucDanhQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
