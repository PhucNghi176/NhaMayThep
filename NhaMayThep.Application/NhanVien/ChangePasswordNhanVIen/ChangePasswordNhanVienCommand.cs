using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.ChangePasswordNhanVIen
{
    public class ChangePasswordNhanVienCommand : IRequest<string>, ICommand
    {
        public ChangePasswordNhanVienCommand(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
        public ChangePasswordNhanVienCommand()
        {
            
        }

        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
