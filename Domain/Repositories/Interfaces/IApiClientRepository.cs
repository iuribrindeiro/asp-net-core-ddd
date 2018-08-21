using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Repositories.Interfaces
{
    public interface IApiClientRepository
    {
        Task<List<ApiClient>> BuscarPorScopos(List<string> scopos);
        Task<ApiClient> BuscarPorNome(string nome);
    }
}