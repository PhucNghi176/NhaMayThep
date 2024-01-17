using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.GetHopDongByIdQuery
{
    public class GetHopDongByIdQuery : IRequest<HopDongDto>, IQuery
    {
        public string Id { get; set; }
        public GetHopDongByIdQuery(string id)
        {
            Id = id;
        }
    }
}
