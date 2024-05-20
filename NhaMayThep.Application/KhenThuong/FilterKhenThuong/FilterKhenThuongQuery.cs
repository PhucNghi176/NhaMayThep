using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.KhenThuong.FilterKhenThuong
{
    public class FilterKhenThuongQuery : IRequest<PagedResult<KhenThuongDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? ChinhSachNhanSuID { get; set; } = 0;
        public string? TenDotKhenThuong { get; set; }
        public string? NgayKhenThuong { get; set; }
        public decimal? TongThuong { get; set; } = decimal.Zero;

        public FilterKhenThuongQuery() { }

        public FilterKhenThuongQuery(int pageNumber, int pageSize, string maSoNhanVien, int chinhSachNhanSuID, string tenDotKhenThuong, string ngayKhenThuong, decimal tongThuong)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaSoNhanVien = maSoNhanVien;
            ChinhSachNhanSuID = chinhSachNhanSuID;
            TenDotKhenThuong = tenDotKhenThuong;
            NgayKhenThuong = ngayKhenThuong;
            TongThuong = tongThuong;
        }
    }
}
