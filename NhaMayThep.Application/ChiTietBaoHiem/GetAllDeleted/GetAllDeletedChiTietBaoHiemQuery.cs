using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllDeleted
{
    public class GetAllDeletedChiTietBaoHiemQuery : IRequest<List<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllDeletedChiTietBaoHiemQuery() { }
    }
}
