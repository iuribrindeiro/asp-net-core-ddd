namespace Domain.Exceptions
{
    public class TentativaLoginInvalidaException : DefaultException
    {
        private const string DefaultMessage = "Tentativa de login inválida";
        public TentativaLoginInvalidaException() : base(DefaultMessage){}
    }
}