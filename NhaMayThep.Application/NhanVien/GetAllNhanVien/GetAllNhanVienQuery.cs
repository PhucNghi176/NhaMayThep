using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVien
{
    public class GetAllNhanVienQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllNhanVienQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetAllNhanVienQuery()
        {

        }
    }
}
