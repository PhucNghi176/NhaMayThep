using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.KhenThuong.GetByPagination
{
    public class GetKhenThuongByPaginationQuery : IRequest<PagedResult<KhenThuongDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetKhenThuongByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetKhenThuongByPaginationQuery() { }
    }
}
