using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
using Microsoft.AspNetCore.Identity;

namespace Identity.Stores
{
    public class RoleStore : IRoleStore<TipoUsuario>
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetRoleNameAsync(TipoUsuario role, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(TipoUsuario role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(TipoUsuario role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TipoUsuario> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TipoUsuario> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}