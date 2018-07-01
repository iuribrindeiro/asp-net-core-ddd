using System.Collections.Generic;
using Domain.Models;

namespace Domain.Exceptions.Usuario 
{
    public class DadosInvalidosUsuarioException : EntidadeNaoProcessavelException
    {
        public DadosInvalidosUsuarioException(IEnumerable<DadoInvalido> errors) : base(errors)
        {
        }
    }
}