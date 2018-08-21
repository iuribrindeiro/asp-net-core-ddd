using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Scope
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public virtual List<UserClaim> UserClaims { get; set; }
        public virtual ApiClient ApiClient { get; set; }
    }
}