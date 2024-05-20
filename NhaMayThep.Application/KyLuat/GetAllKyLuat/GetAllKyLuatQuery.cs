using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.KyLuat.GetAllKyLuat
{
    public class GetAllKyLuatQuery : IRequest<List<KyLuatDTO>>, IQuery
    {
        public GetAllKyLuatQuery() { }
    }
}
