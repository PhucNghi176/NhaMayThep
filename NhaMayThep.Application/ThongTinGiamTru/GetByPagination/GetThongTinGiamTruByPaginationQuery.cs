using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinGiamTru.GetByPagination
{
    public class GetThongTinGiamTruByPaginationQuery : IRequest<PagedResult<ThongTinGiamTruDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetThongTinGiamTruByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinGiamTruByPaginationQuery() { }
    }
}
