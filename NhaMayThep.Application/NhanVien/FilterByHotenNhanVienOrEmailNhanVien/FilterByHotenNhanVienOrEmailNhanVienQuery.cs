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
        public string HoTenHoacEmail { get; set; }
        public FilterByHotenNhanVienOrEmailNhanVienQuery(string HoTenHoacEmail)
        {
            this.HoTenHoacEmail = HoTenHoacEmail;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQuery() { }
    }
}
