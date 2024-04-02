using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Filter
{
    public class FilterLichSuNghiPhepQuery : IRequest<PagedResult<LichSuNghiPhepDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? LoaiNghiPhepID { get; set; } = 0;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? NguoiDuyet { get; set; }
        public string? LyDo { get; set; }
        public string? TenNguoiDuyet { get; set; }
        public string? TenNhanVien { get; set; }

        public FilterLichSuNghiPhepQuery()
        {

        }

        public FilterLichSuNghiPhepQuery(int no, int pagesize, string? MaSoNhanVien, int? LoaiNghiPhepID, DateTime? NgayBatDau, DateTime? NgayKetThuc, string? NguoiDuyet, string? LyDo, string? TenNguoiDuyet, string? TenNhanVien)
        {

            PageNumber = no;
            PageSize = pagesize;
            this.MaSoNhanVien = MaSoNhanVien;
            this.LoaiNghiPhepID = LoaiNghiPhepID;
            this.NguoiDuyet = NguoiDuyet;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
            this.TenNguoiDuyet = TenNguoiDuyet;
            this.TenNhanVien = TenNhanVien;
            this.LyDo=LyDo;
        }

    }
}