using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPagination
{
    public class GetAllPaginationChiTietBaoHiemQuery : IRequest<PagedResult<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllPaginationChiTietBaoHiemQuery() { }
        public GetAllPaginationChiTietBaoHiemQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
