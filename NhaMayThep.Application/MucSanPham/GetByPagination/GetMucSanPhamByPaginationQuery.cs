using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.MucSanPham.GetByPagination
{
    public class GetMucSanPhamByPaginationQuery : IRequest<PagedResult<MucSanPhamDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetMucSanPhamByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetMucSanPhamByPaginationQuery() { }
    }
}
