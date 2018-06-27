using System;
using System.Collections.Generic;
using Domain.Exceptions.Base;
using Domain.Models;

namespace Domain.Exceptions.Usuario
{
    public class DadosInvalidosUsuarioException : DefaultException
    {
        public IEnumerable<DadoInvalidoUsuario> Errors { get; set; }

        public DadosInvalidosUsuarioException(IEnumerable<DadoInvalidoUsuario> errors) : base("Ocorreu um erro ao salvar o usuário") 
            => Errors = errors;
    }
}