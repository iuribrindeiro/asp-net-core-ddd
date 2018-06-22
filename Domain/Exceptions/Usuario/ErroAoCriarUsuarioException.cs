using System;
using System.Collections.Generic;
using Domain.Exceptions.Base;
using Domain.Models;

namespace Domain.Exceptions.Usuario
{
    public class ErroAoCriarUsuarioException : DefaultException
    {
        public IEnumerable<ErroSalvarUsuario> Errors { get; set; }

        public ErroAoCriarUsuarioException(IEnumerable<ErroSalvarUsuario> errors) : base("Ocorreu um erro ao salvar o usuário") 
            => Errors = errors;
    }
}