using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiem.GetBaoHiemById
{
    public class GetBaoHiemByIdQuery : IRequest<BaoHiemDto>, IQuery
    {
        public int Id { get; set; }
        public GetBaoHiemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
