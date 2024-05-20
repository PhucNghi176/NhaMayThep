using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByPagination
{
    public class GetLichSuNghiPhepByPaginationQuery : IRequest<PagedResult<LichSuNghiPhepDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLichSuNghiPhepByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLichSuNghiPhepByPaginationQuery() { }
    }
}
