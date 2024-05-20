using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.GetAll
{
    public class GetAllQuery : IRequest<List<NghiPhepDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}
