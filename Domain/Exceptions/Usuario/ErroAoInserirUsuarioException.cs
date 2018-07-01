using System;
using System.Collections.Generic;
using Domain.Exceptions.Base;

namespace Domain.Exceptions.Usuario
{
    public class ErroAoInserirUsuarioException : DefaultException
    {   
        public ErroAoInserirUsuarioException(string[] errors) : base(errors, "Ocorreram erros ao inserir o usuário") {}
    }
}