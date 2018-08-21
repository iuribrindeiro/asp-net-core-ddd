using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Identity.Services
{
    public class EnviadorTokenCadastroEmailService : IEnviadorTokenCadastroService
    {
        private readonly IMailSenderService _mailSenderService;
        private readonly UserManager<Usuario> _userManager;
        private readonly string _urlCadastroConfirmado;

        public EnviadorTokenCadastroEmailService(IMailSenderService mailSenderService, UserManager<Usuario> userManager, IConfiguration configuration)
        {
            this._mailSenderService = mailSenderService;
            this._userManager = userManager;
            this._urlCadastroConfirmado = configuration.GetSection("UrlEmailConfirm").Value;
        }

        public async Task EnviarTokenAsync(Usuario usuario)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            var urlCadastroConfirmado = $"{_urlCadastroConfirmado}?code={token}&idUsuario={usuario.Id.ToString()}";
            await _mailSenderService.SendEmailAsync(usuario.Email, "Confirmação de Cadastro", urlCadastroConfirmado);
        }
    }
}