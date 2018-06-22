using System;
using System.Threading.Tasks;
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
            await _userManager.CreateAsync(usuario);
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