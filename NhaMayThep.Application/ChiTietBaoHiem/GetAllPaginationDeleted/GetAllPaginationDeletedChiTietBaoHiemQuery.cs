using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted
{
    public class GetAllPaginationDeletedChiTietBaoHiemQuery: IRequest<PagedResult<ChiTietBaoHiemDto>>, IRequest
    {
        public GetAllPaginationDeletedChiTietBaoHiemQuery() { }
        public GetAllPaginationDeletedChiTietBaoHiemQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
