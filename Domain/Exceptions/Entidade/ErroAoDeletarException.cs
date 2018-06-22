using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class ErroAoDeletarException : DefaultException
    {
        public ErroAoDeletarException(Exception exception) : base("Ocorreu um erro ao deletar o registro", exception){}
    }
}