using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.GetUser
{
    public class LoginQuery : IRequest<NhanVienDtoLogin>, IQuery
    {
        public LoginQuery()
        {
            
        }


        public LoginQuery(LoginEntity loginEntity)
        {
            user.UserName = loginEntity.UserName;
            user.Password = loginEntity.Password;
        }
        public required LoginEntity user { get; set; }

    }
}
