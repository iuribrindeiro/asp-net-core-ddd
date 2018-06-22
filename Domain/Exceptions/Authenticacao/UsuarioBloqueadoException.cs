using Domain.Exceptions.Base;

namespace Domain.Exceptions.Authenticacao
{
    public class UsuarioBloqueadoException : DefaultException
    {
        public UsuarioBloqueadoException() : base("Usuário bloquado"){}
    }
}