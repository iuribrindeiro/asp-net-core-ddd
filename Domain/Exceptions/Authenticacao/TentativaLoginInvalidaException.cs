using Domain.Exceptions.Base;

namespace Domain.Exceptions.Authenticacao
{
    public class TentativaLoginInvalidaException : DefaultException
    {
        public TentativaLoginInvalidaException() : base("Tentativa de login inválida"){}
    }
}