using Domain.Services.Interfaces;
using Email.Configuration;
using Email.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

namespace Email.DependencyResolver
{
    public static class EmailDependencyResolverExtension
    {
        public static void AddEmailConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISendGridClient>(c => new SendGridClient(configuration.GetSection("SendGrid").Get<SendGridConfiguration>().SendGridKey));
            services.AddTransient<IMailSenderService, MailSenderService>();
        }
    }
}