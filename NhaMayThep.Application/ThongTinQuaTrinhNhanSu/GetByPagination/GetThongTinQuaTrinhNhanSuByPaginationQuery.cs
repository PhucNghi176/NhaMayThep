using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetByPagination
{
    public class GetThongTinQuaTrinhNhanSuByPaginationQuery : IRequest<PagedResult<ThongTinQuaTrinhNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetThongTinQuaTrinhNhanSuByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinQuaTrinhNhanSuByPaginationQuery() { }
    }
}
