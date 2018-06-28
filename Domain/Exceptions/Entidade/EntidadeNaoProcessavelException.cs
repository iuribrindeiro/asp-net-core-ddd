using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions.Base;
using Domain.Models;

namespace Domain.Exceptions
{
    public class EntidadeNaoProcessavelException : DefaultException
    {
        public IEnumerable<DadoInvalido> Errors { get; }

        public EntidadeNaoProcessavelException(IEnumerable<DadoInvalido> errors,
            string customMessage = "Alguns dos dados que você informou não eram válidos") : base(errors.Select(e => e.Mensagem).ToArray(), customMessage)
        {
            Errors = errors;
        }
    }
}