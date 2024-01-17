using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.GetAllHopDongQuery
{
    public class GetAllHopDongQuery : IRequest<List<HopDongDto>>, IQuery
    {
        public GetAllHopDongQuery() { }
    }
}
