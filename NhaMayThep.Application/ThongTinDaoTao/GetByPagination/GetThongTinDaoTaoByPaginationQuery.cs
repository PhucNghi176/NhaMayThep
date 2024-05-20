using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinDaoTao.GetByPagination
{
    public class GetThongTinDaoTaoByPaginationQuery : IRequest<PagedResult<ThongTinDaoTaoDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetThongTinDaoTaoByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinDaoTaoByPaginationQuery() { }
    }
}
