using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class ErroAoSalvarExcption : DefaultException
    {
        public ErroAoSalvarExcption(Exception exception) : base("Ocorreu um erro ao salvar o registro", exception){}
    }
}