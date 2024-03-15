using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.FilterChinhSachNhanSu
{
    public class FilterChinhSachNhanSuQuery : IRequest<PagedResult<ChinhSachNhanSuDto>>, IQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? MucDo { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public FilterChinhSachNhanSuQuery()
        {
            
        }
        public FilterChinhSachNhanSuQuery(int no, int pageSize, string mucDo, DateTime ngayHieuLuc)
        {
            PageNumber = no;
            PageSize = pageSize;
            MucDo = mucDo;
            NgayHieuLuc = ngayHieuLuc;
        }
    }
}
