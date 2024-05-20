using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrinhDoHocVan.GetAll
{
    public class GetAllQuery : IRequest<List<TrinhDoHocVanDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}

