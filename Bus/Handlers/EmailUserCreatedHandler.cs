using System;
using System.Threading;
using System.Threading.Tasks;
using Bus.Events;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Bus.Handlers
{
    public class EmailUserCreatedHandler : AsyncRequestHandler<UserCreatedEvent>
    {
        private readonly IMailSenderService _mailSenderService;
        private readonly string _urlCadastroConfirmado;

        public EmailUserCreatedHandler(IMailSenderService mailSenderService, IConfiguration configuration)
        {
            _mailSenderService = mailSenderService;
            _urlCadastroConfirmado = configuration.GetSection("UrlEmailConfirm").Value;
        }

        protected override Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {   
            if (cancellationToken.CanBeCanceled)
                return Task.CompletedTask;
            
            var urlCadastroConfirmado = $"{_urlCadastroConfirmado}?code={notification.EmailConfirmationToken}&idUsuario={notification.Usuario.Id.ToString()}";
            
            _mailSenderService.SendEmailAsync(notification.Usuario.Email, "Confirmação de Cadastro", urlCadastroConfirmado);
            return Task.CompletedTask;
        }
    }
}