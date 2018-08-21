using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class IdentityClientMapping : IEntityTypeConfiguration<IdentityClient>
    {
        public void Configure(EntityTypeBuilder<IdentityClient> builder)
        {
            builder.HasBaseType<Client>();
            builder.Property(i => i.Emphasize).IsRequired();
            builder.Property(i => i.Required).IsRequired();
            builder.Property(i => i.ShowInDiscoveryDocument).IsRequired();
        }
    }
}