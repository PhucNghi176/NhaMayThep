using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChinhSachNhanSu.FilterChinhSachNhanSu
{
    public class FilterChinhSachNhanSuQuery : IRequest<PagedResult<ChinhSachNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MucDo { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public FilterChinhSachNhanSuQuery()
        {

        }
        public FilterChinhSachNhanSuQuery(int no, int pageSize, string mucDo, DateTime ngayHieuLuc)
        {
            PageNumber = no;
            PageSize = pageSize;
            MucDo = mucDo;
            NgayHieuLuc = ngayHieuLuc;
        }
    }
}
