using FluentValidation;

namespace NhaMayThep.Application.ThongTinChucVu.GetAllChucVu
{
    public class GetAllChucVuQueryValidator : AbstractValidator<GetAllChucVuQuery>
    {
        public GetAllChucVuQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
