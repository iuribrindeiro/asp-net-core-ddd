namespace Domain.Exceptions
{
    public class RequerAuthenticacaoProviderException : DefaultException
    {
        private const string DefaultMessage = "Requer que se autentique em outro provider";
        public RequerAuthenticacaoProviderException() : base(DefaultMessage){}
    }
}