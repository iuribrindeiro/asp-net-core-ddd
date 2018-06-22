using System;

namespace Domain.Exceptions
{
    public class IdInformadoInvalidoException : Exception
    {
        public string Id { get; set; }
        private const string DefaultMessage = "O id informado não é válido";
        public IdInformadoInvalidoException(string id) : base($"{DefaultMessage}: {id}") => Id = id;
    }
}