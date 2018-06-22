using System;

namespace Domain.Exceptions
{
    public class ErroAoSalvarExcption : DefaultException
    {
        private const string DefaultMessage = "Ocorreu um erro ao salvar o registro";
        public ErroAoSalvarExcption(Exception exception) : base(DefaultMessage, exception){}
    }
}