using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Identity.Stores
{
    public partial class UserStore : IUserEmailStore<Usuario>
    {
        public Task SetEmailAsync(Usuario user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.CadastroConfirmado);
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            user.CadastroConfirmado = confirmed;
            return Task.CompletedTask;
        }

        public async Task<Usuario> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            try
            {
                return await _usuarioRepository.BuscarPorEmailAsync(normalizedEmail.ToLower());
            }
            catch (EntidadeNaoEncontradaException)
            {
                return null;
            }
            
        }

        public Task<string> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email.ToUpper());
        }

        public Task SetNormalizedEmailAsync(Usuario user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;

            return Task.CompletedTask;
        }
    }
}