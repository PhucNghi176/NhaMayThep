using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TangCa.GetAll
{
    public class GetAllTangCaQuery : IRequest<List<TangCaDto>>, IQuery
    {
        public GetAllTangCaQuery()
        {

        }
    }
}
