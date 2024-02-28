using MailKit.Net.Smtp;
using MediatR;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.EmailSender
{
    public class EmailSenderCommandHandler : IRequestHandler<EmailSenderCommand, string>
    {
        public EmailSenderCommandHandler() { }
        public async Task<string> Handle(EmailSenderCommand command, CancellationToken cancellationToken)
        {
            //using mailkit to perform an mail req
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", command.UserEmail));
            email.To.Add(new MailboxAddress("Receiver Name", command.Email));

            email.Subject = command.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = command.Message
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false, cancellationToken);

            // Note: only needed if the SMTP server requires authentication
            smtp.Authenticate(command.UserEmail, command.UserPassword, cancellationToken);

            var result = smtp.Send(email);
            smtp.Disconnect(true, cancellationToken);

            return result;
        }
    }
}
