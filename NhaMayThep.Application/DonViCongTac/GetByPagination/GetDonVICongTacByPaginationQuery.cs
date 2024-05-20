using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.DonViCongTac.GetByPagination
{
    public class GetDonVICongTacByPaginationQuery : IRequest<PagedResult<DonViCongTacDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetDonVICongTacByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetDonVICongTacByPaginationQuery() { }
    }
}
