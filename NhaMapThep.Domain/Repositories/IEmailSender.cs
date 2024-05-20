namespace NhaMapThep.Domain.Repositories
{
    public interface IEmailSender
    {
        public Task<string> SendEmail(string userEmail, string userPassword, string toEmail, string subject, string body);
    }
}
