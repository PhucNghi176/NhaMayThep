using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.EmailSender
{
    public class EmailSenderCommand : ICommand, IRequest<string>
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public EmailSenderCommand() { }

        public EmailSenderCommand(string userEmail, string userPassword, string email, string subject, string message)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;
            Email = email;
            Subject = subject;
            Message = message;
        }
    }
}
