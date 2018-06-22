using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : DefaultException
    {
        public EntidadeNaoEncontradaException() : base("O registro que você procurou não foi encontrado"){}
    }
}