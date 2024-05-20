using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TinhTrangLamViec.GetByPagination
{
    public class GetTinhTrangLamViecByPaginationQuery : IRequest<PagedResult<TinhTrangLamViecDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetTinhTrangLamViecByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetTinhTrangLamViecByPaginationQuery() { }
    }
}
