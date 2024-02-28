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

        public string HoTenHoacEmail { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public FilterByHotenNhanVienOrEmailNhanVienQuery(string HoTenHoacEmail, int pageSize, int pageNumber)
        {
            this.HoTenHoacEmail = HoTenHoacEmail;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQuery() { }
    }
}
