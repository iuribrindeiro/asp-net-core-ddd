using System;
using System.Linq;

namespace Domain.Exceptions.Base
{
    public abstract class DefaultException : Exception
    {
        public const string DefaultMessage =
            "Ocorreu um erro ao executar a operação. Não se preocupe, nossa equipe já está analisando o problema e logo será resolvido";

        public const string DefaultMessageMultipleErrors = 
            "Ocorreram erros ao executar a operação. Não se preocupe, nossa equipe já está analisando o problema e logo será resolvido";

        public string[] Errors { get; }

        public DefaultException(string customMessage = DefaultMessage) : base(customMessage){}

        public DefaultException(string[] errors, string customMesage = DefaultMessageMultipleErrors) : base(customMesage)
        {
            Errors = errors;
        }

        public DefaultException(Exception exception, string customMessage = DefaultMessage) : base(customMessage, exception){}
    }
}