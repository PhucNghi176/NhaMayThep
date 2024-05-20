using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiem.GetPaginationBaoHiem
{
    public class GetBaoHiemByPagination : IRequest<PagedResult<BaoHiemDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetBaoHiemByPagination(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetBaoHiemByPagination() { }
    }
}
