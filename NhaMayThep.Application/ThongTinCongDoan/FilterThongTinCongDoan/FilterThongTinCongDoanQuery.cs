using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinCongDoan.FilterThongTinCongDoan
{
    public class FilterThongTinCongDoanQuery : IRequest<PagedResult<ThongTinCongDoanDto>>, IRequest
    {
        public FilterThongTinCongDoanQuery() { }
        public FilterThongTinCongDoanQuery(
            int pagenumber,
            int pagesize,
            string? id,
            string? nhanvienid,
            string? tennhanvien,
            DateTime? ngaygianhap)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
            Id = id;
            NhanVienId = nhanvienid;
            TenNhanVien = tennhanvien;
            NgayGiaNhap = ngaygianhap;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id { get; set; }
        public string? NhanVienId { get; set; }
        public string? TenNhanVien { get; set; }
        public DateTime? NgayGiaNhap { get; set; }
    }
}
