using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByPagination
{
    public class GetHoaDonCongTacNhanVienByPaginationQuery : IRequest<PagedResult<HoaDonCongTacNhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetHoaDonCongTacNhanVienByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetHoaDonCongTacNhanVienByPaginationQuery() { }
    }
}
