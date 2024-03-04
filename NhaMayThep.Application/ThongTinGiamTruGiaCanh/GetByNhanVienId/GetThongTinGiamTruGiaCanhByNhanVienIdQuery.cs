using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdQuery: IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdQuery(string id)
        {
            Id = id;
        }
        public GetThongTinGiamTruGiaCanhByNhanVienIdQuery() { }
        public string Id { get; set; }
    }
}
