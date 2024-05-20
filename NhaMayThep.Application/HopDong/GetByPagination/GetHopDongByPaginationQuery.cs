using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.HopDong.GetByPagination
{
    public class GetHopDongByPaginationQuery : IRequest<PagedResult<HopDongDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetHopDongByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetHopDongByPaginationQuery() { }
    }
}
