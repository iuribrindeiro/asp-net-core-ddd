using System;
using System.Threading.Tasks;
using Bus.Events;
using Domain.DTO;
using Domain.Entidades;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Delegators
{
    public class UsuarioServiceDelegator : IUsuariosService
    {
        private readonly IUsuariosService _usuariosService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMediator _mediator;

        public UsuarioServiceDelegator(IUsuariosService usuariosService, UserManager<Usuario> userManager, IMediator mediator)
        {
            _usuariosService = usuariosService;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task SalvarAsync(Usuario usuario, string password)
        {
            await _usuariosService.SalvarAsync(usuario, password);
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            await _mediator.Send(new UserCreatedEvent()
            {
                Usuario = usuario,
                EmailConfirmationToken = token 
            }); 
        }

        public Task AtualizarAsync(Usuario usuario) => _usuariosService.AtualizarAsync(usuario);

        public Task DeletarAsync(Guid id) => _usuariosService.DeletarAsync(id);

        public Task<Usuario> BuscarAsync(string id) => _usuariosService.BuscarAsync(id);

        public UsuariosPaginadosDTO BuscarUsuarios(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1) => _usuariosService.BuscarUsuarios(valueOfAnyTextField, pageSize, pageIndex);

        public Task ConfirmUserEmailAsync(string code, string idUsuario) => _usuariosService.ConfirmUserEmailAsync(code, idUsuario);
    }
}