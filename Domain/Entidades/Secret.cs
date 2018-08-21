using System;

namespace Domain.Entidades
{
    public class Secret
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public virtual ApiClient ApiClient { get; set; }
    }
}