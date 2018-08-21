namespace Domain.Entidades
{
    public class IdentityClient : Client
    {
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
    }
}