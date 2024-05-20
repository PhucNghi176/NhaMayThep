using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetByPagination
{
    public class GetQuaTrinhNhanSuByPaginationQuery : IRequest<PagedResult<QuaTrinhNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetQuaTrinhNhanSuByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetQuaTrinhNhanSuByPaginationQuery() { }
    }
}
