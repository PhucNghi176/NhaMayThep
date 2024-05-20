using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.PhuCapNhanVien.FilterPhuCapNhanVien
{
    public class FilterPhuCapNhanVienQuery : IRequest<PagedResult<PhuCapNhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? PhuCap { get; set; } = 0;

        public FilterPhuCapNhanVienQuery() { }
        public FilterPhuCapNhanVienQuery(int no, int pageSize, int phuCap)
        {
            PageNumber = no;
            PageSize = pageSize;
            PhuCap = phuCap;
        }
    }
}
