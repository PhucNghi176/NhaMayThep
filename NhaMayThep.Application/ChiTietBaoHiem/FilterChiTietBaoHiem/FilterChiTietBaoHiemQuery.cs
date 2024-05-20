using MediatR;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterChiTietBaoHiem
{
    public class FilterChiTietBaoHiemQuery : IRequest<PagedResult<ChiTietBaoHiemDto>>, IRequest
    {
        public FilterChiTietBaoHiemQuery() { }
        public FilterChiTietBaoHiemQuery(
            int pagenumber,
            int pagesize,
            string? id,
            int mabaohiem,
            string? tenbaohiem,
            DateTime? ngayhieuluc,
            DateTime? ngayketthuc)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
            Id = id;
            MaBaoHiem = mabaohiem;
            TenBaohiem = tenbaohiem;
            NgayHieuLuc = ngayhieuluc;
            NgayKetThuc = ngayketthuc;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id { get; set; }
        public int MaBaoHiem { get; set; }
        public string? TenBaohiem { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
    }
}
