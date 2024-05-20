using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeletedPagination
{
    public class GetAllThongTinCongDoanPaginationDeletedQuery : IRequest<PagedResult<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanPaginationDeletedQuery() { }
        public GetAllThongTinCongDoanPaginationDeletedQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
