using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllPagination
{
    public class GetAllThongTinCongDoanPaginationQuery : IRequest<PagedResult<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanPaginationQuery() { }
        public GetAllThongTinCongDoanPaginationQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
