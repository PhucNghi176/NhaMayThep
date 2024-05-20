using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery : IRequest<List<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
