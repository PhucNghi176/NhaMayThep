using MediatR;
using NhaMapThep.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterByHoVaTenNhanVienQuery : IRequest<List<ChiTietBaoHiemDto>>, IRequest
    {
        public FilterByHoVaTenNhanVienQuery() { }
        public FilterByHoVaTenNhanVienQuery(string hoVaTen, int pageNumber, int pageSize)
        {
            HoVaTen = hoVaTen;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public string HoVaTen { get;set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
