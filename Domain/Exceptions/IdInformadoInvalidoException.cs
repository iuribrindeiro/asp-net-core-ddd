using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class IdInformadoInvalidoException : DefaultException
    {
        public string Id { get; set; }
        private const string DefaultMessage = "O id informado não é válido";
        public IdInformadoInvalidoException(string id) : base($"{DefaultMessage}: {id}") => Id = id;
    }
}