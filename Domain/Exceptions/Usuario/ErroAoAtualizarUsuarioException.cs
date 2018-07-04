using Domain.Exceptions.Base;

namespace Domain.Exceptions.Usuario
{
    public class ErroAoAtualizarUsuarioException : DefaultException
    {
        public ErroAoAtualizarUsuarioException(string[] errors) : base(errors, "Ocorreram erros ao atualizar o usuário") {}
    }
}