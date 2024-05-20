using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.CanCuocCongDan.GetPagination
{
    public class GetCCCDByPaginationQuery : IRequest<PagedResult<CanCuocCongDanDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetCCCDByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetCCCDByPaginationQuery() { }
    }
}
