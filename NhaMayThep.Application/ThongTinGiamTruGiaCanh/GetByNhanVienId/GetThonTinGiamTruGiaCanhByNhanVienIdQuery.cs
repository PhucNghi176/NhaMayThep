using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId
{
    public class GetThonTinGiamTruGiaCanhByNhanVienIdQuery : IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetThonTinGiamTruGiaCanhByNhanVienIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
