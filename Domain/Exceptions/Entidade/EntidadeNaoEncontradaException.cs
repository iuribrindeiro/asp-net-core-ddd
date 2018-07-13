using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : DefaultException
    {
        public string Id { get; set; }
        public string Entidade { get; set; }
        
        public EntidadeNaoEncontradaException(string id, string entidade) : base("O registro que você procurou não foi encontrado"){}
        
        public EntidadeNaoEncontradaException(string entidade) : base("O registro que você procurou não foi encontrado"){}
    }
}