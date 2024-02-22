using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeletedPaginition
{
    public class GetAllThongTinCongDoanPaginationDeletedQuery: IRequest<PagedResult<ThongTinCongDoanDto>>, IQuery
    {
        public GetAllThongTinCongDoanPaginationDeletedQuery() { }
        public GetAllThongTinCongDoanPaginationDeletedQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
