using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAll
{
    public class GetAllThongTinCongDoanQuery : IRequest<PagedResult<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanQuery() { }
        public GetAllThongTinCongDoanQuery(int pagenumber, int pagesize) 
        {
            PageNumber= pagenumber;
            PageSize= pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
