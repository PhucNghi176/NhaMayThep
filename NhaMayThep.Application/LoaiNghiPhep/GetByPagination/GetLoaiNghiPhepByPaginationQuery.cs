using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LoaiNghiPhep.GetByPagination
{
    public class GetLoaiNghiPhepByPaginationQuery : IRequest<PagedResult<LoaiNghiPhepDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetLoaiNghiPhepByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLoaiNghiPhepByPaginationQuery() { }
    }
}
