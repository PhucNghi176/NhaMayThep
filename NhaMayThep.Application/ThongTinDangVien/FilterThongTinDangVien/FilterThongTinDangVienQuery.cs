using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.FilterThongTinDangVien
{
    public class FilterThongTinDangVienQuery : IRequest<PagedResult<ThongTinDangVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? DonViCongTacID { get; set; }
        public string? ChucVuDang { get; set; }
        public string? TrinhDoChinhTri { get; set; }
        public DateTime? NgayVaoDang { get; set; }
        public string? CapDangVien { get; set; }

        public FilterThongTinDangVienQuery() { }
        public FilterThongTinDangVienQuery(int no, int pageSize , int donViCongTacID, string chucVuDang, string trinhDoChinhTri, DateTime ngayVaoDang, string capDangVien)
        {
            PageNumber = no;
            PageSize = pageSize;
            this.DonViCongTacID = donViCongTacID;
            ChucVuDang = chucVuDang;
            TrinhDoChinhTri = trinhDoChinhTri;
            NgayVaoDang = ngayVaoDang;
            CapDangVien = capDangVien;
        }
    }
}
