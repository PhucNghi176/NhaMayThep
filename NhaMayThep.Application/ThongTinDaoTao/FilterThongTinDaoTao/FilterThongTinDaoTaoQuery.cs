using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinDaoTao.FilterThongTinDaoTao
{
    public class FilterThongTinDaoTaoQuery : IRequest<PagedResult<ThongTinDaoTaoDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? TrinhDoVanHoa { get; set; } = 0;
        public int? MaTrinhDoHocVanID { get; set; } = 0;
        public string? NhanVienID { get; set; }
        public string? TenTruong { get; set; }
        public string? ChuyenNganh { get; set; }
        public DateTime? NamTotNghiep { get; set; }

        public FilterThongTinDaoTaoQuery() { }

        public FilterThongTinDaoTaoQuery(int pageNumber, int pageSize, int trinhDoVanHoa, int maTrinhDoHocVan, string nhanVienID, string tenTruong, string chuyenNganh, DateTime? namTotNghiep)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TrinhDoVanHoa = trinhDoVanHoa;
            MaTrinhDoHocVanID = maTrinhDoHocVan;
            NhanVienID = nhanVienID;
            TenTruong = tenTruong;
            ChuyenNganh = chuyenNganh;
            NamTotNghiep = namTotNghiep;
        }
    }
}
