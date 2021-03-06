﻿using System;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entidades;

namespace Domain.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task SalvarAsync(Usuario usuario, string password);
        Task AtualizarAsync(Usuario usuario);
        Task DeletarAsync(Guid id);
        Task<Usuario> BuscarAsync(string id);
        UsuariosPaginadosDTO BuscarUsuarios(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1);
        Task ConfirmUserEmailAsync(string code, string idUsuario);
    }
}