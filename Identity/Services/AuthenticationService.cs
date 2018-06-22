using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Exceptions.Authenticacao;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<Usuario> _signInManager;

        public AuthenticationService(SignInManager<Usuario> signInManager) => _signInManager = signInManager;

        public async Task LoginAsync(Usuario usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario, usuario.PasswordHash, usuario.Lembrar, true);
            
            if (result.RequiresTwoFactor)
                throw new RequerAuthenticacaoProviderException();
            
            if (result.IsLockedOut)
                throw new UsuarioBloqueadoException();
            
            if (!result.Succeeded)
                throw new TentativaLoginInvalidaException();
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}