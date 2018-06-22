using System.Threading;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Stores
{
    public class UserPassowordStore : UserStore, IUserPasswordStore<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserPassowordStore(IUsuarioRepository usuarioRepository) : base(usuarioRepository) => _usuarioRepository = usuarioRepository;

        public Task SetPasswordHashAsync(Usuario user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            _usuarioRepository.Atualizar(user);

            return Task.CompletedTask;
        }

        public async Task<string> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {

            try
            {
                return (await _usuarioRepository.BuscarPorLoginOuEmailAsync(user)).PasswordHash;
            }
            catch (EntidadeNaoEncontradaException)
            {
                return "";
            }
        }

        public async Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            try
            {
                return (await _usuarioRepository.BuscarPorLoginOuEmailAsync(user)).PasswordHash.Length > 0;
            }
            catch (EntidadeNaoEncontradaException)
            {
                return false;
            }
        }
    }
}