using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByPagination
{
    public class GetThongTinGiamTruGiaCanhByPaginationQuery : IRequest<PagedResult<ThongTinGiamTruGiaCanhDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }
        public GetThongTinGiamTruGiaCanhByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetThongTinGiamTruGiaCanhByPaginationQuery() { }
    }
}
