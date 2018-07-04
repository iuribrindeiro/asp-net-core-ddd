using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Exceptions.Usuario;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Identity.Errors;
using Identity.Stores;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
    public class UsuarioService : IUsuariosService
    {
        private readonly UserManager<Usuario> _userManager;

        private readonly Dictionary<TipoIdentityErrorEnum, string> _errorsEntidadeInvalida =
            new Dictionary<TipoIdentityErrorEnum, string>()
            {
                {TipoIdentityErrorEnum.Email, TipoIdentityErrorEnum.Email.ToString()},
                {TipoIdentityErrorEnum.Password, TipoIdentityErrorEnum.Password.ToString()},
                {TipoIdentityErrorEnum.Permissao, TipoIdentityErrorEnum.Permissao.ToString()},
                {TipoIdentityErrorEnum.UserName, TipoIdentityErrorEnum.UserName.ToString()}
            };

        public UsuarioService(UserManager<Usuario> userManager) => _userManager = userManager;

        public async Task SalvarAsync(Usuario usuario, string password)
        {
            var result = await _userManager.CreateAsync(usuario, password);

            if (result.Succeeded)
                return;

            if (ErrosDeValidacao(result.Errors))
                throw new DadosInvalidosUsuarioException(result.Errors.Cast<CustomIdentityError>().Select(e =>
                    new DadoInvalido()
                    {
                        Mensagem = e.Description,
                        Nome = e.Tipo.ToString()
                    }));
            
            throw new ErroAoInserirUsuarioException(result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            var savedUsuario = await _userManager.FindByIdAsync(usuario.Id.ToString());
            usuario.PasswordHash = savedUsuario.PasswordHash;
            var result = await _userManager.UpdateAsync(usuario);
            
            if (result.Succeeded)
                return;

            if (ErrosDeValidacao(result.Errors))
                throw new DadosInvalidosUsuarioException(result.Errors.Cast<CustomIdentityError>().Select(e =>
                    new DadoInvalido()
                    {
                        Mensagem = e.Description,
                        Nome = e.Tipo.ToString()
                    }));
            
            throw new ErroAoAtualizarUsuarioException(result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task DeletarAsync(Guid id)
        {
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task<Usuario> BuscarAsync(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            return usuario ?? throw new EntidadeNaoEncontradaException();
        }

        public UsuariosPaginadosDTO BuscarUsuarios(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1) => (_userManager.Users as IUsuarioRepository).BuscarPorQualquerCampoTexto(valueOfAnyTextField, pageSize, pageIndex);

        private bool ErrosDeValidacao(IEnumerable<IdentityError> errors)
        {
            return errors.Cast<CustomIdentityError>().Any(e => _errorsEntidadeInvalida.ContainsKey(e.Tipo));
        }
    }
}