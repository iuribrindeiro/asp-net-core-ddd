using System;

namespace Domain.Exceptions
{
    public class ErroAoDeletarException : DefaultException
    {
        private const string DefaultMessage = "Ocorreu um erro ao deletar o registro";
        public ErroAoDeletarException(Exception exception) : base(DefaultMessage, exception){}
    }
}