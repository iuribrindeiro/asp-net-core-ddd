using System.Collections.Generic;
using Domain.Exceptions.Base;
using Domain.Models;

namespace Domain.Exceptions
{
    public class EntidadeNaoProcessavelException : DefaultException
    {   
        public IEnumerable<DadoInvalido> Errors { get; }

        public const string DefaultMessage = "Alguns dos dados que você informou não eram válidos"; 

        public EntidadeNaoProcessavelException(IEnumerable<DadoInvalido> errors,
            string customMessage = DefaultMessage) : base(customMessage)
        {
            Errors = errors;
        }
    }
}