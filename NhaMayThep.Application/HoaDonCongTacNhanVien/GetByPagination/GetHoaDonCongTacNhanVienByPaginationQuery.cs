using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByPagination
{
    public class GetHoaDonCongTacNhanVienByPaginationQuery : IRequest<PagedResult<HoaDonCongTacNhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }
        public GetHoaDonCongTacNhanVienByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetHoaDonCongTacNhanVienByPaginationQuery() { }
    }
}
