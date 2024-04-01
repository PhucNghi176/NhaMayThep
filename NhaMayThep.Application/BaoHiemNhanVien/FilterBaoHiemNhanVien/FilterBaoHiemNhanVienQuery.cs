using MediatR;
using NhaMapThep.Application.Common.Pagination;

namespace NhaMayThep.Application.BaoHiemNhanVien.FilterBaoHiemNhanVien
{
    public class FilterBaoHiemNhanVienQuery : IRequest<PagedResult<BaoHiemNhanVienDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }

        public FilterBaoHiemNhanVienQuery() { }

        public FilterBaoHiemNhanVienQuery(int pageNumber, int pageSize, string maSoNhanVien)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaSoNhanVien = maSoNhanVien;
        }
    }
}
