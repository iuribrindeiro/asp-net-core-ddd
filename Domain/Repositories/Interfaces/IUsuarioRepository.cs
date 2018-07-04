using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entidades;

namespace Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository : IQueryable<Usuario>
    {
        Task SalvarAsync(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(Guid id);
        Task<Usuario> BuscarAsync(Guid id);
        Task<Usuario> BuscarPorNomeAsync(string normalizedUserName);
        Task<Usuario> BuscarPorEmailAsync(string normalizedEmail);
        UsuariosPaginadosDTO BuscarPorQualquerCampoTexto(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1);
    }
}