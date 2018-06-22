using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class ErroAoBuscarException : DefaultException
    {
        public ErroAoBuscarException(Exception exception) : base("Ocorreu um erro ao buscar o registro", exception){}
    }
}