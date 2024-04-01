using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.Filter
{
    public class FilterLuongThoiGIanQuery : IRequest<PagedResult<LuongThoiGianDto>>, IQuery
    {
        public FilterLuongThoiGIanQuery()
        {
        }

        public FilterLuongThoiGIanQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }

        public FilterLuongThoiGIanQuery(int pageNo, int pageSize, string? maSoNhanVien, string? hoVaTen, decimal? luongNam, decimal? luongThang, decimal? luongTuan, decimal? luongNgay, decimal? luongGio, DateTime? ngayApDung) : this(pageNo, pageSize)
        {
            MaSoNhanVien = maSoNhanVien;
            HoVaTen = hoVaTen;
            LuongNam = luongNam;
            LuongThang = luongThang;
            LuongTuan = luongTuan;
            LuongNgay = luongNgay;
            LuongGio = luongGio;
            NgayApDung = ngayApDung;
        }

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public string? HoVaTen { get; set; }
        public decimal? LuongNam { get; set; }
        public decimal? LuongThang { get; set; }
        public decimal? LuongTuan { get; set; }
        public decimal? LuongNgay { get; set; }
        public decimal? LuongGio { get; set; }
        public DateTime? NgayApDung { get; set; }
    }
}
