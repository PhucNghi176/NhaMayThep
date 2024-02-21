using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
