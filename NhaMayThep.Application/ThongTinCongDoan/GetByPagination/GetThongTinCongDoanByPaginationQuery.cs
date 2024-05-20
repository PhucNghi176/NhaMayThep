using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByPagination
{
    public class GetThongTinCongDoanByPaginationQuery : IRequest<PagedResult<ThongTinCongDoanDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetThongTinCongDoanByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinCongDoanByPaginationQuery() { }
    }
}
