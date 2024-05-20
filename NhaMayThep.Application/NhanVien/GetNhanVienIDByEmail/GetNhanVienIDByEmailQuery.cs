using MediatR;
using NhaMayThep.Application.Common.Interfaces;

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
