using System;
using System.Collections.Generic;
using Domain.Entidades.Base;

namespace Domain.Entidades
{
    public class Client : BaseEntity
    {
        public bool Habilitado { get; set; }
        public string Nome { get; set; }
        public string NomeExibicao { get; set; }
        public string Descricao { get; set; }
        public virtual List<UserClaim> UserClaims { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}