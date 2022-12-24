using System.Net.Mail;

namespace NewsletterApi.Domain.Providers
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;

        public EmailSender(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MailMessage
            {
                From = new MailAddress("newsletter@example.com"),
                Subject = subject,
                Body = body
            };
            message.To.Add(new MailAddress(to));
            await _smtpClient.SendMailAsync(message);
        }
    }
}
