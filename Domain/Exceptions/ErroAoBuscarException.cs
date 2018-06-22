using System;

namespace Domain.Exceptions
{
    public class ErroAoBuscarException : DefaultException
    {
        private const string DefaultMessage = "Ocorreu um erro ao buscar o registro"; 
        
        public ErroAoBuscarException(Exception exception) : base(DefaultMessage, exception){}
    }
}