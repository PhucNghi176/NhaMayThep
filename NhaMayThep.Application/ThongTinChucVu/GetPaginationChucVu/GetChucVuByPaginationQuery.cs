using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.GetPaginationChucVu
{
    public class GetChucVuByPaginationQuery : IRequest<PagedResult<ChucVuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetChucVuByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
