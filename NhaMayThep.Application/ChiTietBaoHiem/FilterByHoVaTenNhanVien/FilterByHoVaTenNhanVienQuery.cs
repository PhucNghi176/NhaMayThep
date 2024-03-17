using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterByHoVaTenNhanVienQuery : IRequest<PagedResult<ChiTietBaoHiemDto>>, IRequest
    {
        public FilterByHoVaTenNhanVienQuery() { }
        public FilterByHoVaTenNhanVienQuery(int pagenumber,int pagesize,string hoVaTen)
        {
            HoVaTen = hoVaTen;
            PageNumber = pagenumber;
            PageSize = pagesize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string HoVaTen { get;set; }

    }
}
