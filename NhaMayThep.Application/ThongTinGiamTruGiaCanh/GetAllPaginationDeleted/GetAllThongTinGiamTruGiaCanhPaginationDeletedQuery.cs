using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPaginationDeleted
{
    public class GetAllThongTinGiamTruGiaCanhPaginationDeletedQuery : IRequest<PagedResult<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public GetAllThongTinGiamTruGiaCanhPaginationDeletedQuery() { }
        public GetAllThongTinGiamTruGiaCanhPaginationDeletedQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
