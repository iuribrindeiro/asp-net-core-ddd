using System;

namespace Domain.Exceptions
{
    public abstract class DefaultException : Exception
    {
        private const string DefaultMessage =
            "Ocorreu um erro ao executar a operação. Não se preocupe, nossa equipe já está analisando o problema e logo será resolvido";

        public DefaultException() : base(DefaultMessage){}

        public DefaultException(string customMessage) : base(customMessage){}

        public DefaultException(Exception exception) : base(DefaultMessage, exception){}

        public DefaultException(string customMessage, Exception exception) : base(customMessage, exception){}
    }
}