using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
{
    public class FilterByHotenNhanVienOrEmailNhanVienQuery : IRequest<List<NhanVienDto>>, IQuery
    {
        public string request { get; set; }
        public FilterByHotenNhanVienOrEmailNhanVienQuery(string request)
        {
            this.request = request;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQuery() { }
    }
}
