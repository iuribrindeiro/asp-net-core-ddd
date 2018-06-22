using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class ErroAoAtualizarException : DefaultException
    {
        private const string DefaultMesage = "Ocorreu um erro ao atualizar o registro";
        
        public ErroAoAtualizarException(Exception exception) : base(DefaultMesage, exception){}
    }
}