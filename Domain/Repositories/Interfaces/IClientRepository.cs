using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task SalvarAsync(Client client);
        Task AtualizarAsync(Client client);
        Task RemoverAsync(Client client);
        Task<List<Client>> BuscarTodosAsync();
    }
}