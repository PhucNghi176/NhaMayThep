using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted
{
    public class GetThongTinGiamTruGiaCanhByIdDeletedQuery : IRequest<ThongTinGiamTruGiaCanhDto>, IQuery
    {
        public GetThongTinGiamTruGiaCanhByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetThongTinGiamTruGiaCanhByIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
