using System;

namespace Domain.Exceptions.Base
{
    public abstract class DefaultException : Exception
    {
        private const string DefaultMessage =
            "Ocorreu um erro ao executar a operação. Não se preocupe, nossa equipe já está analisando o problema e logo será resolvido";

        public DefaultException(string customMessage) : base(customMessage){}

        public DefaultException(string customMessage, Exception exception) : base(customMessage, exception){}
    }
}