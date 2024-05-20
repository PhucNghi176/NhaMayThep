using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TrinhDoHocVan.GetByPagination
{
    public class GetTrinhDoHocVanByPaginationQuery : IRequest<PagedResult<TrinhDoHocVanDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetTrinhDoHocVanByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetTrinhDoHocVanByPaginationQuery() { }
    }
}
