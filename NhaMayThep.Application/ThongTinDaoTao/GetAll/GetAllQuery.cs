using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDaoTao.GetAll
{
    public class GetAllQuery : IRequest<List<ThongTinDaoTaoDto>>, IQuery
    {
        public GetAllQuery() { }
    }
}
