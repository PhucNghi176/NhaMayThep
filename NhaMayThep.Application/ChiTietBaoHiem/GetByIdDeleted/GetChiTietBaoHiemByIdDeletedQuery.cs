using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetByIdDeleted
{
    public class GetChiTietBaoHiemByIdDeletedQuery : IRequest<ChiTietBaoHiemDto>, IRequest
    {
        public GetChiTietBaoHiemByIdDeletedQuery(string id)
        {
            Id = id;
        }
        public GetChiTietBaoHiemByIdDeletedQuery() { }
        public string Id { get; set; }
    }
}
