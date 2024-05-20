using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.PhongBan.GetByPagination
{
    public class GetPhongBanByPaginationQuery : IRequest<PagedResult<PhongBanDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetPhongBanByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetPhongBanByPaginationQuery() { }
    }
}
