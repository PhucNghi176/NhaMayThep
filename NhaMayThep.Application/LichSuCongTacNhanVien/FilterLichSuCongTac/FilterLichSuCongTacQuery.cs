using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.FilterLichSuCongTac
{
    public class FilterLichSuCongTacQuery : IRequest<PagedResult<LichSuCongTacNhanVienDto>>, IQuery
    {
        public FilterLichSuCongTacQuery() { }


        public FilterLichSuCongTacQuery(int pageNumber, int pageSize, string? maSoNhanVien, int? loaiCongTacID, DateTime? ngayBatDau, DateTime? ngayKetThuc, string? noiCongTac)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaSoNhanVien = maSoNhanVien;
            LoaiCongTacID = loaiCongTacID;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NoiCongTac = noiCongTac;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public string? HoVaTen { get; set; }
        public int? LoaiCongTacID { get; set; } = 0;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NoiCongTac { get; set; }
    }
}
