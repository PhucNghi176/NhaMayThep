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
        public FilterByHoVaTenNhanVienQuery(string hoVaTen)
        {
            HoVaTen = hoVaTen;
        }
        public string HoVaTen { get;set; }
    }
}
