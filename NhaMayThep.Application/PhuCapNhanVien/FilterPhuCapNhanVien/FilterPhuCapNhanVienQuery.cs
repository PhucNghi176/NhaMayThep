using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapNhanVien.FilterPhuCapNhanVien
{
    public class FilterPhuCapNhanVienQuery : IRequest<PagedResult<PhuCapNhanVienDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? PhuCap { get; set; } = 0;

        public FilterPhuCapNhanVienQuery() { }
        public FilterPhuCapNhanVienQuery(int no, int pageSize, int phuCap)
        {
            PageNumber = no;
            PageSize = pageSize;
            PhuCap = phuCap;
        }
    }
}
