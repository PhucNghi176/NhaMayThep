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
    public class GetHoTenNhanVienByEmailQuery : IRequest<List<string>>, IQuery
    {
        public string Email { get; set; }
        public GetHoTenNhanVienByEmailQuery(string Email)
        {
            this.Email = Email;
        }
        public GetHoTenNhanVienByEmailQuery() { }
    }
}
