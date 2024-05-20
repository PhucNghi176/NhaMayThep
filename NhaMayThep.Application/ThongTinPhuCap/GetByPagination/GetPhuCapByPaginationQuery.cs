using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinPhuCap.GetByPagination
{
    public class GetPhuCapByPaginationQuery : IRequest<PagedResult<PhuCapDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetPhuCapByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetPhuCapByPaginationQuery() { }
    }
}
