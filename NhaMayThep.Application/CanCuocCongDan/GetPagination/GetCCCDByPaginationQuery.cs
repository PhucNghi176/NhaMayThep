using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.GetPagination
{
    public class GetCCCDByPaginationQuery : IRequest<PagedResult<CanCuocCongDanDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public GetCCCDByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetCCCDByPaginationQuery() { }
    }
}
