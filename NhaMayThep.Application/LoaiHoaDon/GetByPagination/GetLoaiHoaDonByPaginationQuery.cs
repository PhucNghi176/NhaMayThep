using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LoaiHoaDon.GetByPagination
{
    public class GetLoaiHoaDonByPaginationQuery : IRequest<PagedResult<LoaiHoaDonDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLoaiHoaDonByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLoaiHoaDonByPaginationQuery() { }
    }
}
