using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Domain.DTO;
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
            await _applicationContext.Usuarios.AddAsync(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            var local = _applicationContext.Usuarios.Local.FirstOrDefault(entry => entry.Id.Equals(usuario.Id));
            if (local != null)
                _applicationContext.Entry(local).State = EntityState.Detached;
            
            _applicationContext.Entry(usuario).State = EntityState.Modified;
        }

        public void Deletar(Guid id)
        {
            var usuario = _applicationContext.Usuarios.Find(id);
            if (usuario == null)
                throw new EntidadeNaoEncontradaException();

            _applicationContext.Usuarios.Remove(usuario);
        }

        public async Task<Usuario> BuscarAsync(Guid id)
        {
            var usuario = await _applicationContext.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new EntidadeNaoEncontradaException();

            return usuario;
        }

        public async Task<Usuario> BuscarPorNomeAsync(string normalizedName)
        {
            var usuario = await _applicationContext.Usuarios.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedName);
            if (usuario == null)
                throw new EntidadeNaoEncontradaException();

            return usuario;
        }

        public async Task<Usuario> BuscarPorEmailAsync(string normalizedEmail)
        {
            var usuario = await _applicationContext.Usuarios.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail);
                
            if (usuario == null)
                throw new EntidadeNaoEncontradaException();

            return usuario;
        }

        public UsuariosPaginadosDTO BuscarPorQualquerCampoTexto(string valueOfAnyTextField, int pageSize = 10, int pageIndex = 1)
        {
            var query = !String.IsNullOrEmpty(valueOfAnyTextField) ? _applicationContext.Usuarios.Where(u =>
                u.NormalizedUserName.Contains(valueOfAnyTextField.ToUpper()) ||
                u.CPFCNPJ.Contains(valueOfAnyTextField) || u.NormalizedEmail.Contains(valueOfAnyTextField.ToUpper()) ||
                u.Ddd.Contains(valueOfAnyTextField) || u.Telefone.Contains(valueOfAnyTextField)) : _applicationContext.Usuarios;

            return new UsuariosPaginadosDTO(query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                query.Count(), pageIndex, pageSize);
        }

        public IEnumerator<Usuario> GetEnumerator() => _applicationContext.Usuarios.AsQueryable().GetEnumerator();
        
        public Type ElementType => _applicationContext.Usuarios.AsQueryable().ElementType;
        
        public Expression Expression => _applicationContext.Usuarios.AsQueryable().Expression;
        
        public IQueryProvider Provider => _applicationContext.Usuarios.AsQueryable().Provider;
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}