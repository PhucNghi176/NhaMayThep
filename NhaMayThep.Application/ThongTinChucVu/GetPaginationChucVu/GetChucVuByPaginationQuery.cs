using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinChucVu.GetPaginationChucVu
{
    public class GetChucVuByPaginationQuery : IRequest<PagedResult<ChucVuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetChucVuByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetChucVuByPaginationQuery() { }
    }
}
