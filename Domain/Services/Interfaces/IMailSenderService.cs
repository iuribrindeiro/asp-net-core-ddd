using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IMailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}