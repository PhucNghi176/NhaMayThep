using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TinhTrangLamViec.GetAllTinhTrangLamViec
{
    public class GetAllTinhTrangLamViecQuery : IRequest<List<TinhTrangLamViecDTO>>, IQuery
    {
    }
}
