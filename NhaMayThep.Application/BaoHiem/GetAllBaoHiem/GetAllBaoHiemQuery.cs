using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BaoHiem.GetAllBaoHiem
{
    public class GetAllBaoHiemQuery : IRequest<List<BaoHiemDto>>, IQuery
    {
        public GetAllBaoHiemQuery() { }
    }
}
