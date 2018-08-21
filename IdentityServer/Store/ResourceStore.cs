using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Repositories.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace IdentityServer.Store
{
    public class ResourceStore : IResourceStore
    {
        private readonly IClientRepository _clientRepository;
        private readonly IApiClientRepository _apiClientRepository;
        private readonly IIdentityClientRepository _identityClientRepository;

        public ResourceStore(IClientRepository clientRepository, IApiClientRepository apiClientRepository, IIdentityClientRepository identityClientRepository)
        {
            this._clientRepository = clientRepository;
            this._apiClientRepository = apiClientRepository;
            this._identityClientRepository = identityClientRepository;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var identityClients = await this._identityClientRepository.BuscarPorNomesAsync(scopeNames.ToList());

            return identityClients.Select(a => new IdentityResource() {
                Description = a.Descricao,
                DisplayName = a.NomeExibicao,
                Emphasize = a.Emphasize,
                Enabled = a.Habilitado,
                Name = a.Nome,
                UserClaims = a.UserClaims.Select(u => u.Nome).ToArray(),
                ShowInDiscoveryDocument = a.ShowInDiscoveryDocument,
                Required = a.Required
            });
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var apiClients = await this._apiClientRepository.BuscarPorScopos(scopeNames.ToList());

            return apiClients.Select(a => new ApiResource() {
                
            });
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}