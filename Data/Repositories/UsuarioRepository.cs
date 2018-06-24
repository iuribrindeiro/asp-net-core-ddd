using System;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entidades;
using Domain.Exceptions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UsuarioRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;
        
        public async Task SalvarAsync(Usuario usuario)
        {
            try
            {
                await _applicationContext.Set<Usuario>().AddAsync(usuario);
            }
            catch (Exception exception)
            {
                throw new ErroAoSalvarExcption(exception);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _applicationContext.Set<Usuario>().Update(usuario);
            }
            catch (Exception e)
            {
                throw new ErroAoAtualizarException(e);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var usuario = _applicationContext.Set<Usuario>().Find(id);
                if (usuario == null)
                    throw new EntidadeNaoEncontradaException();

                _applicationContext.Set<Usuario>().Remove(usuario);
            }
            catch (EntidadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ErroAoDeletarException(e);
            }
        }

        public async Task<Usuario> BuscarAsync(Guid id)
        {
            try
            {
                var usuario = await _applicationContext.Set<Usuario>().FindAsync(id);
                if (usuario == null)
                    throw new EntidadeNaoEncontradaException();

                return usuario;
            }
            catch (EntidadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ErroAoBuscarException(e);
            }
        }

        public async Task<Usuario> BuscarPorNomeAsync(string nome)
        {
            try
            {
                var usuario = await _applicationContext.Set<Usuario>().FirstOrDefaultAsync(u => u.UserName == nome);
                if (usuario == null)
                    throw new EntidadeNaoEncontradaException();

                return usuario;
            }
            catch (EntidadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ErroAoBuscarException(e);
            }
        }

        public async Task<Usuario> BuscarPorLoginOuEmailAsync(Usuario user)
        {
            try
            {
                var usuario = await _applicationContext.Set<Usuario>()
                    .FirstOrDefaultAsync(u => u.UserName == user.UserName || u.Email == user.Email);

                if (usuario == null)
                    throw new EntidadeNaoEncontradaException();

                return usuario;
            }
            catch (EntidadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ErroAoBuscarException(e);
            }
        }

        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            try
            {
                var usuario = await _applicationContext.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == email);
                
                if (usuario == null)
                    throw new EntidadeNaoEncontradaException();

                return usuario;
            }
            catch (EntidadeNaoEncontradaException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ErroAoBuscarException(e);
            }
        }
    }
}