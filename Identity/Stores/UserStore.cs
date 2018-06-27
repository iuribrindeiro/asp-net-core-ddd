using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Stores
{
    public partial class UserStore : IUserStore<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserStore(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        public Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(Usuario user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.UserName = userName;

            return Task.FromResult<object>(null);
        }

        public Task<string> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            user.NormalizedUserName = normalizedName;
            
            return Task.FromResult<object>(null); 
        }

        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                await _usuarioRepository.SalvarAsync(user);
                return IdentityResult.Success;
            }
            catch (ErroAoSalvarExcption excption)
            {
                return IdentityResult.Failed(new IdentityError { Description = excption.Message });
            }
        }

        public Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            try
            {
                _usuarioRepository.Atualizar(user);
                return Task.FromResult(IdentityResult.Success);
            }
            catch (ErroAoAtualizarException exception)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError {Description = exception.Message}));
            }
        }

        public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _usuarioRepository.Deletar(user.Id);
                return Task.FromResult(IdentityResult.Success);
            }
            catch (DefaultException e)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError {Description = e.Message}));
            }
        }

        public async Task<Usuario> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            if (!Guid.TryParse(userId, out var idGuid))
                throw new IdInformadoInvalidoException(userId);
                
            return await _usuarioRepository.BuscarAsync(idGuid);
        }

        public async Task<Usuario> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            try
            {
                return await _usuarioRepository.BuscarPorNomeAsync(normalizedUserName);
            }
            catch (EntidadeNaoEncontradaException)
            {
                return null;
            }
        }
        
        public void Dispose()
        {
        }
    }
}