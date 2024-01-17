using FluentValidation;

namespace NhaMayThep.Application.LoaiHopDong.GetAllLoaiHopDong
{
    public class GetAllLoaiHopDongQueryValidator : AbstractValidator<GetAllLoaiHopDongQuery>
    {
        public GetAllLoaiHopDongQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {

        }
    }
}
