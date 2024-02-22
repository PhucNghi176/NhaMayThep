using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
{
    public class FilterByHotenNhanVienOrEmailNhanVienQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {

        public string request { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public FilterByHotenNhanVienOrEmailNhanVienQuery(string request, int pageSize, int pageNumber)
        {
            this.request = request;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQuery() { }
    }
}
