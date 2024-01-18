using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;

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
