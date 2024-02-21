using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetNhanVienIDByEmail
{
    public class GetNhanVienIDByEmailQuery : IRequest<string>, IQuery
    {
        public GetNhanVienIDByEmailQuery()
        {

        }

        public GetNhanVienIDByEmailQuery(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}
