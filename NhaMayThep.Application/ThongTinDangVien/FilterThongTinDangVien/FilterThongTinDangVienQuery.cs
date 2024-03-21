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
        public int? DonViCongTacID { get; set; }=0;
        public int? ChucVuDangID { get; set; } = 0;
        public int? TrinhDoChinhTriID { get; set; } = 0;
        public DateTime? NgayVaoDang { get; set; }
        public int? CapDangVienID { get; set; } = 0;

        public FilterThongTinDangVienQuery() { }
        public FilterThongTinDangVienQuery(int no, int pageSize , int donViCongTacID, int chucVuDang, int trinhDoChinhTri, DateTime ngayVaoDang, int capDangVien)
        {
            PageNumber = no;
            PageSize = pageSize;
            this.DonViCongTacID = donViCongTacID;
            ChucVuDangID = chucVuDang;
            TrinhDoChinhTriID = trinhDoChinhTri;
            NgayVaoDang = ngayVaoDang;
            CapDangVienID = capDangVien;
        }
    }
}
