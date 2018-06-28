using System;
using System.Collections.Generic;
using Domain.Exceptions.Base;

namespace Domain.Exceptions.Usuario
{
    public class ErroAoInserirUsuarioException : DefaultException
    {
        public string[] Errors { get; }
        
        public ErroAoInserirUsuarioException(string[] errors) : base("Ocorreram erros ao inserir o usuário") => Errors = errors;
    }
}