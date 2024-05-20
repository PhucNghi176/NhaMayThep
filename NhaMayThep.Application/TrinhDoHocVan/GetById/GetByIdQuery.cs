using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrinhDoHocVan.GetById
{
    public class GetByIdQuery : IRequest<TrinhDoHocVanDto>, IQuery
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
