using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetById
{
    public class GetChiTietBaoHiemByIdQuery : IRequest<ChiTietBaoHiemDto>, IRequest
    {
        public GetChiTietBaoHiemByIdQuery() { }
        public GetChiTietBaoHiemByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
