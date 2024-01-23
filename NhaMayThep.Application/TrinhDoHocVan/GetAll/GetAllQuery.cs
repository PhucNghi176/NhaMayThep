using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System.Collections.Generic;

namespace NhaMayThep.Application.TrinhDoHocVan.GetAll
{
    public class GetAllQuery : IRequest<List<TrinhDoHocVanDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}

