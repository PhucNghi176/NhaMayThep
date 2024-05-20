using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllPagination
{
    public class GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery : IRequest<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery() { }
        public GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
