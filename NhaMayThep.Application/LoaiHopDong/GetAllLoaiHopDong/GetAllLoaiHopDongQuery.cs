using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.GetAllLoaiHopDong
{
    public class GetAllLoaiHopDongQuery : IRequest<List<LoaiHopDongDto>>, IQuery
    {
        public GetAllLoaiHopDongQuery() { }
    }
}
