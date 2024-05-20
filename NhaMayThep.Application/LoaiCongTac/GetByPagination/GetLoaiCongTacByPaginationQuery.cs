using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LoaiCongTac.GetByPagination
{
    public class GetLoaiCongTacByPaginationQuery : IRequest<PagedResult<LoaiCongTacDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLoaiCongTacByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLoaiCongTacByPaginationQuery() { }
    }
}
