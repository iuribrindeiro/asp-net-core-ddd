using Domain.Exceptions.Base;

namespace Domain.Exceptions.Usuario
{
    public class TokenConfirmacaoEmailInvalidoException : DefaultException
    {
        public string Token { get; }
        
        public TokenConfirmacaoEmailInvalidoException(string token) : base($"O token \"{token}\" não é válido")
        {
            Token = token;
        }
    }
}