using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted
{
    public class GetAllPaginationDeletedChiTietBaoHiemQuery : IRequest<PagedResult<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllPaginationDeletedChiTietBaoHiemQuery() { }
        public GetAllPaginationDeletedChiTietBaoHiemQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
