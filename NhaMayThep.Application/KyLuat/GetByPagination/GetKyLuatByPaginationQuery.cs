using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.KyLuat.GetByPagination
{
    public class GetKyLuatByPaginationQuery : IRequest<PagedResult<KyLuatDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetKyLuatByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetKyLuatByPaginationQuery() { }
    }
}
