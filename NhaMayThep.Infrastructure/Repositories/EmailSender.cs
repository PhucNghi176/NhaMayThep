using MailKit.Net.Smtp;
using MimeKit;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class EmailSender : IEmailSender
    {
        public Task<string> SendEmail(string userEmail, string userPassword, string toEmail, string subject, string body)
        {
            //using mailkit to perform an mail req
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", userEmail));
            email.To.Add(new MailboxAddress("Receiver Name", toEmail));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);

            // Note: only needed if the SMTP server requires authentication
            smtp.Authenticate(userEmail, userPassword);

            var result = smtp.SendAsync(email);
            smtp.Disconnect(true);

            return result;
        }
    }
}
