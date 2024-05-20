using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByPagination
{
    public class GetLichSuCongTacNhanVienByPaginationQuery : IRequest<PagedResult<LichSuCongTacNhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLichSuCongTacNhanVienByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLichSuCongTacNhanVienByPaginationQuery() { }
    }
}
