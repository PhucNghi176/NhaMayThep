using MediatR;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAll
{
    public class GetAllChiTietBaoHiemQuery : IRequest<List<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllChiTietBaoHiemQuery() { }
    }
}
