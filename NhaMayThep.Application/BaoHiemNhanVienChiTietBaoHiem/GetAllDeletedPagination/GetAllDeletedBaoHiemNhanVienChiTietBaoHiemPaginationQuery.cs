using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeletedPagination
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery : IRequest<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery() { }
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
