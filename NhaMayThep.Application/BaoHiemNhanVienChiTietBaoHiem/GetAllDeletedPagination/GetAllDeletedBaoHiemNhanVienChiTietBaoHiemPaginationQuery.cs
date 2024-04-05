using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeletedPagination
{
    public class GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery: IRequest<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery() { }
        public GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery(int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
