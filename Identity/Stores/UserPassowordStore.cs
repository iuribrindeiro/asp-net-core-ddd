using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Stores
{
    public partial class UserStore : IUserPasswordStore<Usuario>
    {
        public Task SetPasswordHashAsync(Usuario user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken) => Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken) => Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
}