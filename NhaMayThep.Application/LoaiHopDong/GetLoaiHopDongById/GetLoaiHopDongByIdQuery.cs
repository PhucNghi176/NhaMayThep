using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.GetLoaiHopDongById
{
    public class GetLoaiHopDongByIdQuery : IRequest<LoaiHopDongDto>, IQuery
    {
        public GetLoaiHopDongByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
