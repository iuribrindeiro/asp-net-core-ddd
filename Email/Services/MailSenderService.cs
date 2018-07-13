using System.Threading.Tasks;
using Domain.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Email.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly ISendGridClient _sendGridClient;

        public MailSenderService(ISendGridClient sendGridClient) => _sendGridClient = sendGridClient;

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("iuribrindeiro@gmail.com", "Mega Lógica"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            
            msg.AddTo(new EmailAddress(email));

            return _sendGridClient.SendEmailAsync(msg);
        }
    }
}