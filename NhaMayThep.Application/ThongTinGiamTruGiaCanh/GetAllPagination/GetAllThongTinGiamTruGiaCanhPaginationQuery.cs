using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPagination
{
    public class GetAllThongTinGiamTruGiaCanhPaginationQuery : IRequest<PagedResult<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetAllThongTinGiamTruGiaCanhPaginationQuery()
        {

        }
        public GetAllThongTinGiamTruGiaCanhPaginationQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
