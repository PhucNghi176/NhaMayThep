using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.GetById
{
    public class GetByIdQuery : IRequest<NghiPhepDto>, IQuery
    {
        public GetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
