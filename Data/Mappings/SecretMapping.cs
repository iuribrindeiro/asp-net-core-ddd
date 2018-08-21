using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class SecretMapping : IEntityTypeConfiguration<Secret>
    {
        public void Configure(EntityTypeBuilder<Secret> builder)
        {
            builder.HasOne(s => s.ApiClient).WithMany(a => a.Secrets).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.Expiration).IsRequired(false);
            builder.Property(s => s.Type).IsRequired();
            builder.Property(s => s.Value).IsRequired();
        }
    }
}