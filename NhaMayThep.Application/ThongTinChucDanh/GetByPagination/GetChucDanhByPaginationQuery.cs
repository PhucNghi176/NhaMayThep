using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinChucDanh.GetByPagination
{
    public class GetChucDanhByPaginationQuery : IRequest<PagedResult<ChucDanhDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetChucDanhByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetChucDanhByPaginationQuery() { }
    }
}
