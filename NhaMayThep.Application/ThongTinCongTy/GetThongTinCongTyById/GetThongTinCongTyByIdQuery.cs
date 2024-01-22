using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.GetThongTinCongTyById
{
    public class GetThongTinCongTyByIdQuery : IRequest<ThongTinCongTyDto>, IQuery
    {
        public GetThongTinCongTyByIdQuery(int maDoanhNghiep)
        {
            MaDoanhNghiep = maDoanhNghiep;
        }

        public int MaDoanhNghiep { get; set; }
    }
}