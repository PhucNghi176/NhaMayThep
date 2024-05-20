using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.Admin.AdminAccount.Create
{
    public class CreateAdminAccountCommand : IRequest<string>, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public CreateAdminAccountCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
