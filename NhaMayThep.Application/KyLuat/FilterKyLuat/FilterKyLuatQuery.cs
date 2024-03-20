using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.FilterKyLuat
{
    public class FilterKyLuatQuery : IRequest<PagedResult<KyLuatDTO>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? ChinhSachNhanSuID { get; set; } = 0;
        public string? TenDotKyLuat { get; set; }
        public DateTime? NgayKiLuat { get; set; }
        public decimal? TongPhat { get; set; } = decimal.Zero;

        public FilterKyLuatQuery() { }
        public FilterKyLuatQuery(int pageNumber, int pageSize, string? maSoNhanVien, int? chinhSachNhanSuID, string? tenDotKyLuat, DateTime? ngayKiLuat, decimal? tongPhat)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MaSoNhanVien = maSoNhanVien;
            ChinhSachNhanSuID = chinhSachNhanSuID;
            TenDotKyLuat = tenDotKyLuat;
            NgayKiLuat = ngayKiLuat;
            TongPhat = tongPhat;
        }
    }
}
