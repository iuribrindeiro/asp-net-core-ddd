using System;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entidades;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Delegators
{
    public class UsuarioServiceDecorator : IUsuariosService
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IEnviadorTokenCadastroService _enviadorTokenCadastroService;

        public UsuarioServiceDecorator(IUsuariosService usuariosService, IEnviadorTokenCadastroService enviadorTokenCadastroService)
        {
            _usuariosService = usuariosService;
            this._enviadorTokenCadastroService = enviadorTokenCadastroService;
        }

        public async Task SalvarAsync(Usuario usuario, string password)
        {
            await _usuariosService.SalvarAsync(usuario, password);
            _enviadorTokenCadastroService.EnviarTokenAsync(usuario);
        }

        public Task AtualizarAsync(Usuario usuario) => _usuariosService.AtualizarAsync(usuario);

        public Task DeletarAsync(Guid id) => _usuariosService.DeletarAsync(id);

        public Task<Usuario> BuscarAsync(string id) => _usuariosService.BuscarAsync(id);

        public UsuariosPaginadosDTO BuscarUsuarios(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1) => _usuariosService.BuscarUsuarios(valueOfAnyTextField, pageSize, pageIndex);

        public Task ConfirmUserEmailAsync(string code, string idUsuario) => _usuariosService.ConfirmUserEmailAsync(code, idUsuario);
    }
}