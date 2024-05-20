using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.GetByPagination
{
    public class GetNhanVienByPaginationQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetNhanVienByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetNhanVienByPaginationQuery() { }
    }
}
