using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetByPagination
{
    public class GetThongTinQuaTrinhNhanSuByPaginationQuery : IRequest<PagedResult<ThongTinQuaTrinhNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }
        public GetThongTinQuaTrinhNhanSuByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinQuaTrinhNhanSuByPaginationQuery() { }
    }
}
