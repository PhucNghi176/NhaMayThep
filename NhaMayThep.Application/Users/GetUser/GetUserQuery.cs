using MediatR;
using NhaMapThep.Application.Users;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMapThep.Application.Authenticate.Login
{
    public class GetUserQuery : IRequest<UserDto>, IQuery
    {
        public GetUserQuery(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string userName { get; set; }
        public string password { get; set; }
    }
}
