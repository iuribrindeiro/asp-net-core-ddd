using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Repositories.Interfaces
{
    public interface IIdentityClientRepository
    {
        Task<List<IdentityClient>> BuscarPorNomesAsync(List<string> nomes);
    }
}