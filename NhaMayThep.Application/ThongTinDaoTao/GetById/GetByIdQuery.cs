using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDaoTao.GetById
{
    public class GetByIdQuery : IRequest<ThongTinDaoTaoDto>, IQuery
    {
        public GetByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
