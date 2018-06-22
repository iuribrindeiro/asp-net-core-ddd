using System;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task SalvarAsync(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(Guid id);
        Task<Usuario> BuscarAsync(Guid id);
        Task<Usuario> BuscarPorNomeAsync(string nome);
        Task<Usuario> BuscarPorLoginOuEmailAsync(Usuario usuario);
    }
}