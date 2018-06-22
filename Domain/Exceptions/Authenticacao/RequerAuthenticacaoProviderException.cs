using Domain.Exceptions.Base;

namespace Domain.Exceptions.Authenticacao
{
    public class RequerAuthenticacaoProviderException : DefaultException
    {
        public RequerAuthenticacaoProviderException() : base("Requer que se autentique em outro provider"){}
    }
}