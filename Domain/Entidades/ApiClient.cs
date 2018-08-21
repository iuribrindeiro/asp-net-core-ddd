using System.Collections.Generic;

namespace Domain.Entidades
{
    public class ApiClient : Client
    {
        public virtual List<Secret> Secrets { get; set; }
        public virtual List<Scope> Scopes { get; set; }
    }
}