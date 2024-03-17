using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh
{
    public class FilterThongTinGiamTruGiaCanhQuery : IRequest<PagedResult<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public FilterThongTinGiamTruGiaCanhQuery() { }
        public FilterThongTinGiamTruGiaCanhQuery(
            int pagenumber,
            int pagesize, 
            string? nhanvienid,
            string? tennhanvien,
            int magiamtru,
            string? tengiamtru,
            string? cancuoc,
            DateTime ngayphuthuoc,
            DateTime ngaytao)
        {
            PageSize = pagesize;
            PageNumber = pagenumber;
            NhanVienID = nhanvienid;
            TenNhanVien = tennhanvien;
            MaGiamTruID = magiamtru;
            TenGiamTru = tengiamtru;
            CanCuocCongDan = cancuoc;
            NgayXacNhanPhuThuoc = ngayphuthuoc;
            NgayTao = ngaytao;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NhanVienID { get; set; }
        public string? TenNhanVien { get; set; }
        public int MaGiamTruID { get; set; }
        public string? TenGiamTru { get; set; }
        public string? CanCuocCongDan { get; set; }
        public DateTime? NgayXacNhanPhuThuoc { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
