using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetUser
{
    public class GetNhanVienQuery : IRequest<NhanVienDto>, IQuery
    {
        public GetNhanVienQuery()
        {
            
        }


        public GetNhanVienQuery(LoginEntity loginEntity)
        {
            user.UserName = loginEntity.UserName;
            user.Password = loginEntity.Password;
        }

       public required LoginEntity user { get; set; }
    }
}
