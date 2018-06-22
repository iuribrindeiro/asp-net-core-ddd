namespace Domain.Exceptions
{
    public class UsuarioBloqueadoException : DefaultException
    {
        private const string DefaultMessage = "Usuário bloquado";
        public UsuarioBloqueadoException() : base(DefaultMessage){}
    }
}