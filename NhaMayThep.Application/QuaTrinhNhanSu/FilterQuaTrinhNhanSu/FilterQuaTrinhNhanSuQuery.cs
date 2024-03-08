using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.FilterQuaTrinhNhanSu
{
    public class FilterQuaTrinhNhanSuQuery : IRequest<PagedResult<QuaTrinhNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? MaSoNhanVien { get; set; }
        public int? LoaiQuaTrinhID { get; set; } = 0;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? PhongBanID { get; set; } = 0;
        public int? ChucVuID { get; set; } = 0;
        public int? ChucDanhID { get; set; } = 0;
        public FilterQuaTrinhNhanSuQuery() { }
        public FilterQuaTrinhNhanSuQuery(int no, int pageSize, DateTime ngayTao, string maSoNhanVien, 
            int loaiQuaTrinhID, DateTime ngayBatDau, DateTime ngayKetThuc, int phongBanID, int chucVuID, int chucDanhID)
        {
            PageNumber = no;
            PageSize = pageSize;
            NgayTao = ngayTao;
            MaSoNhanVien = maSoNhanVien;
            LoaiQuaTrinhID = loaiQuaTrinhID;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            PhongBanID = phongBanID;
            ChucVuID = chucVuID;
            ChucDanhID = chucDanhID;
        }
    }
}
