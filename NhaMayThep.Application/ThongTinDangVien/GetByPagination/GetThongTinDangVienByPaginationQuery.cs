using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinDangVien.GetByPagination
{
    public class GetThongTinDangVienByPaginationQuery : IRequest<PagedResult<ThongTinDangVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetThongTinDangVienByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinDangVienByPaginationQuery() { }
    }
}
