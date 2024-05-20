using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.GetAllNhanVienWithoutHopDong
{
    public class GetAllNhanVienWithoutHopDongQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllNhanVienWithoutHopDongQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetAllNhanVienWithoutHopDongQuery()
        {

        }
    }
}
