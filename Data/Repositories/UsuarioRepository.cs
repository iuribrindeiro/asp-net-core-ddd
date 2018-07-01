﻿using System;
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
            await _applicationContext.Set<Usuario>().AddAsync(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _applicationContext.Update(usuario);
        }

        public void Deletar(Guid id)
        {
            var usuario = _applicationContext.Usuarios.Find(id);
            if (usuario == null)
                throw new EntidadeNaoEncontradaException();

            _applicationContext.Remove(usuario);
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
    }
}