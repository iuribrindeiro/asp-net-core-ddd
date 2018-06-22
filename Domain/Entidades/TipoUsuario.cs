using System;

namespace Domain.Entidades
{
    public class TipoUsuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}