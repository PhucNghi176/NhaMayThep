using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetByPagination
{
    public class GetChiTietNgayNghiPhepByPaginationQuery : IRequest<PagedResult<ChiTietNgayNghiPhepDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetChiTietNgayNghiPhepByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetChiTietNgayNghiPhepByPaginationQuery() { }
    }
}
