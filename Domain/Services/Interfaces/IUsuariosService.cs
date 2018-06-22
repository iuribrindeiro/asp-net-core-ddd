using System;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task SalvarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task DeletarAsync(Guid id);
        Task<Usuario> BuscarAsync(string id);
    }
}