using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ScopeMapping : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Required).IsRequired();
            builder.Property(s => s.ShowInDiscoveryDocument).IsRequired();
            builder.HasMany(s => s.UserClaims);
            builder.HasOne(s => s.ApiClient).WithMany(a => a.Scopes).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.DisplayName).IsRequired();
            builder.Property(s => s.Emphasize).IsRequired();
        }
    }
}