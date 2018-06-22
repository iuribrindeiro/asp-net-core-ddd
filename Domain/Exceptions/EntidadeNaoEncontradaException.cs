using System;

namespace Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : DefaultException
    {
        private const string DefaultMessage = "O registro que você procurou não foi encontrado";

        public EntidadeNaoEncontradaException() : base(DefaultMessage){}
    }
}