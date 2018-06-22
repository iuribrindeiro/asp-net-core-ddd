using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using Domain.Exceptions.Usuario;
using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
    public class UsuarioService : IUsuariosService
    {
        private readonly UserManager<Usuario> _userManager;
        
        public UsuarioService(UserManager<Usuario> userManager) => _userManager = userManager;

        public async Task SalvarAsync(Usuario usuario)
        {
            var result = await _userManager.CreateAsync(usuario);
            
            if (!result.Succeeded)
                throw new ErroAoCriarUsuarioException(result.Errors.Select(e => new ErroSalvarUsuario() { Descricao = e.Description, Codigo = e.Code}));
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            await _userManager.UpdateAsync(usuario);
        }

        public async Task DeletarAsync(Guid id)
        {
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<Usuario> BuscarAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}