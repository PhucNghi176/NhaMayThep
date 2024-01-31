using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.GetByPagination
{
    public class GetLoaiHoaDonByPaginationQuery : IRequest<PagedResult<LoaiHoaDonDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }
        public GetLoaiHoaDonByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetLoaiHoaDonByPaginationQuery() { }
    }
}
